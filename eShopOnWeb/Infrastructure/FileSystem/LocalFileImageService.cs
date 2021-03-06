﻿using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.FileSystem
{
    public class LocalFileImageService : IImageService
    {
        private readonly IHostingEnvironment _env;

        public LocalFileImageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public byte[] GetImageBytesById(int id)
        {
            try
            {
                var contentRoot = _env.ContentRootPath + "//Pics";
                var path = Path.Combine(contentRoot, id + ".png");
                return File.ReadAllBytes(path);
            }
            catch (FileNotFoundException ex)
            {
                throw new CatalogImageMissingException(ex);
            }
        }
    }
}
