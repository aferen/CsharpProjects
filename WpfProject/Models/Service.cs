using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WpfProject.Models
{
    public class Service<T>: ControllerBase
    {
        private string baseURL = Helper.BaseUrl;
        private string url = null;
        public async Task<List<T>> GetJsonList(string action)
        {           
            url = baseURL + action;
            return await GetList(url);
        }
        public async Task<List<T>> GetJsonList(string action, int? id)
        {
            url = baseURL + action +"/"+id;
            return await GetList(url);
        }
        public async Task<T> GetJson(string action, int? id)
        {
            url = baseURL + action + "/" + id;
            return await Get(url);
        }
        public async Task<List<T>> GetJsonList(string action, int? id1, int? id2)
        {
            url = baseURL + action + "/" + id1 + "/" + id2;
            return await GetList(url);
        }
        public async Task<List<T>> GetJsonList(string action, int? id1, int? id2, int? id3)
        {
            url = baseURL + action + "/" + id1 + "/" + id2 + "/" + id3;
            return await GetList(url);
        }
        public async Task<List<T>> GetJsonList(string action, string parameter)
        {
            url = baseURL + action + "?" + parameter;
            return await GetList(url);
        }
        public async Task<List<T>> GetJsonList(string action, int? id, string parameter)
        {
            url = baseURL + action + "/" + id+"?"+parameter;
            return await GetList(url);
        }
        public async Task<List<T>> GetList(string baseURL)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            List<T> data = await content.ReadAsAsync<List<T>>();
                            if (data != null)
                            {
                                return data;
                            }
                            else
                            {
                                return null;
                            }
                        }   
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<T> Get(string baseURL)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            T data = await content.ReadAsAsync<T>();
                            if (data != null)
                            {
                                return data;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public async Task<IActionResult> GetImage(string baseURL)
        {
            Byte[] img = null;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            img = await content.ReadAsByteArrayAsync();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return File(img, "image/jpeg");
        }






    }
}
