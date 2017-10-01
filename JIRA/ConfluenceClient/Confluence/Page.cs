using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConfluenceClient.Confluence
{
    public class Page
    {
        private const string urlParameters = "?expand=space,body.storage,version,container";
        private string server;
        private int pageId;
        private string baseUrl;

        public string title {get; set;}
        public string status { get; set; }
        public string type { get; set; }
        public Version version { get; set; }
        public Body body { get; set; }

        public Page() { 
        }

        public Page(string server, int pageId) 
        {
            this.server = server;
            this.pageId = pageId;
            this.baseUrl = server + "/rest/api/content/" + pageId;

            var newPage = ConfluenceClient.Get<Page>(baseUrl, urlParameters);
            this.title = newPage.title;
            this.status = newPage.status;
            this.type = newPage.type;
            this.version = newPage.version;
            this.body = newPage.body;
        }

        public void Update() {
            //Confluence always want the page number to be incremented by one
            this.version.number++;

            var updatedPage = ConfluenceClient.Put<Confluence.Page>(baseUrl, this);
            this.title = updatedPage.title;
            this.status = updatedPage.status;
            this.type = updatedPage.type;
            this.version = updatedPage.version;
            this.body = updatedPage.body;
        }

    }
}
