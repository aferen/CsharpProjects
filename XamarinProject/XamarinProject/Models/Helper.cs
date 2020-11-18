using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.Models
{
    public static class Helper
    {
        public static string BaseUrl { get; } = "http://192.168.1.100:8018/api/";
        public static List<Product> productsCaseList = new List<Product>();

    }
}
