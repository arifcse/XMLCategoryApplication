using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLCategoryApplication
{
    public class Category
    {
        public List<XMLDoc> XMLDocList;
        public List<Category> subCategoryList;
        public string CategoryName;

        public Category(string categoryName)
        {
            this.CategoryName = categoryName;
            XMLDocList = new List<XMLDoc>();
            subCategoryList = new List<Category>();
        }

        public void CreateXMLDocument(string ContentName)
        {
            XMLDoc doc = new XMLDoc(ContentName);
            if (!(XMLDocList.Select(i => i.Content == ContentName).Count() > 0))
            {
                XMLDocList.Add(doc);
            }
        }

        public void CreateCategory(Category subCategory)
        {
            subCategoryList.Add(subCategory);
        }

        public void InsertXMLDocumentIntoSubCategory(string CategoryName, string XMLDocumentName)
        {
            if (this.CategoryName == CategoryName)
            {
                //this.XMLDocList.Add(new XMLDoc(XMLDocumentName));
                this.CreateXMLDocument(XMLDocumentName);
                return;
            }

            if (this.subCategoryList.Count > 0)
            {
                foreach (Category cat in this.subCategoryList)
                {
                    cat.InsertXMLDocumentIntoSubCategory(CategoryName, XMLDocumentName);
                }
            }

            //throw new Exception("Category Not Found");
        }

        public void DeleteXMLDocumentFromSubCategory(string CategoryName, string XMLDocumentName)
        {
            if (this.CategoryName == CategoryName && this.XMLDocList.Count > 0 && this.XMLDocList.Contains(new XMLDoc(XMLDocumentName)))
            {
                this.XMLDocList.Remove(new XMLDoc(XMLDocumentName));
                return;
            }

            if (this.subCategoryList.Count > 0)
            {
                foreach (Category cat in this.subCategoryList)
                {
                    cat.DeleteXMLDocumentFromSubCategory(CategoryName, XMLDocumentName);
                }
            }

            //throw new Exception("Document Not Found");
        }

        public void ShowXMLDocumentContent(string XMLDocumentName)
        {
            //if (this.CategoryName == CategoryName)
            //{
            if (this.XMLDocList.Contains(new XMLDoc(XMLDocumentName)))
            {
                XMLDoc doc = this.XMLDocList.Find(i => i.Content == XMLDocumentName);
                foreach (string item in doc.KeywordList)
                {
                    Console.Write("" + item + "\t");
                }
                return;
            }
            //}

            if (this.subCategoryList.Count > 0)
            {
                foreach (Category cat in this.subCategoryList)
                {
                    cat.ShowXMLDocumentContent(XMLDocumentName);
                }
            }
        }

        public void InsertXMLDocumentContent(string XMLDocumentName, string KeyWord)
        {
            //if (this.CategoryName == CategoryName)
            //{
            if (this.XMLDocList.Contains(new XMLDoc(XMLDocumentName)))
            {
                XMLDoc doc = this.XMLDocList.Find(i => i.Content == XMLDocumentName);
                doc.insertKeyword(KeyWord);
                return;
            }
            //}

            if (this.subCategoryList.Count > 0)
            {
                foreach (Category cat in this.subCategoryList)
                {
                    cat.InsertXMLDocumentContent(XMLDocumentName, KeyWord);
                }
            }

            // throw new Exception("Document Not Found");
        }

        public void DeleteXMLDocumentContent(string XMLDocumentName, string KeyWord)
        {
            //if (this.CategoryName == CategoryName)
            //{
            if (this.XMLDocList.Contains(new XMLDoc(XMLDocumentName)))
            {
                XMLDoc doc = this.XMLDocList.Find(i => i.Content == XMLDocumentName);
                doc.deleteKeyword(KeyWord);
                return;
            }
            //}

            if (this.subCategoryList.Count > 0)
            {
                foreach (Category cat in this.subCategoryList)
                {
                    cat.DeleteXMLDocumentContent(XMLDocumentName, KeyWord);
                }
            }

            //throw new Exception("Document Not Found");
        }

        public void DisplayAllSubCategories(string CategoryName)
        {
            if (this.subCategoryList.Count > 0)
            {
                Category cat = this.subCategoryList.Find(i => i.CategoryName == CategoryName);
                if (cat != null)
                {
                    foreach (Category catItem in cat.subCategoryList)
                    {
                        Console.WriteLine("\t" + catItem.CategoryName);
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayAllElements()
        {
            foreach (XMLDoc xmldoc in XMLDocList)
            {
                Console.WriteLine("\t" + xmldoc.Content);
            }

            foreach (Category cat in subCategoryList)
            {
                Console.WriteLine("\t" + cat.CategoryName);
                cat.DisplayAllElements();
            }
            Console.WriteLine();
        }

        public void ReturnXMLDocumentsWithKeyword(string KeywordName)
        {
            foreach (XMLDoc doc in this.XMLDocList)
            {
                foreach (string item in doc.KeywordList)
                {
                    if (item.Contains(KeywordName))
                    {
                        Console.WriteLine("\t" + doc.Content);
                        break;
                    }
                }
            }

            foreach (Category cat in subCategoryList)
            {
                if (cat.XMLDocList.Count > 0)
                {
                    cat.ReturnXMLDocumentsWithKeyword(KeywordName);
                }
            }
        }
    }
}
