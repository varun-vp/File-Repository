﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadExample.Models
{
    public class FileUpload
    {
        public IFormFile FormFile{get; set;}
    }
}
