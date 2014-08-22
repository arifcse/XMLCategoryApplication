using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLCategoryApplication
{
    public class XMLDoc
    {
        public XMLDoc(string str)
        {
            setContent(str);
            KeywordList = new List<string>();
        }

        public string Content;

        public List<string> KeywordList;

        public string getContent()
        {
            return this.Content;
        }

        public void setContent(string str)
        {
            this.Content = str;
        }

        public void insertKeyword(string keyword)
        {
            if (!KeywordList.Contains(keyword))
            {
                KeywordList.Add(keyword);
            }
        }

        public void deleteKeyword(string keyword)
        {
            if (KeywordList.Contains(keyword))
            {
                KeywordList.Remove(keyword);
            }
        }
    }
}
