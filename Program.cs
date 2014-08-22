using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLCategoryApplication
{
    public class Program
    {
        // Main Program For Testing..
        static void Main(string[] args)
        {
            RunTest();
        }

        public static void RunTest()
        {
            Console.WriteLine();
            Console.Write(@"
USAGE: (Choose Operation) Type Any of the Following Numbers:                                                        
1   Create Root Category(Recreate will delete previous root. Example: RootCategory)
2   Create a subcategory for a category(Example: RootCategory Category1)
3   Create an XML Document For A category(Example: RootCategory Document1)
4   Insert A keyword into an XML document(Example: Document1 Tree)
5   Delete A keyword from an XML document(Example: Document1 Tree)
6   Display All elements of root category
7   Display All subcategory under particular category like 'Database'(Example: Database)
8   Insert an XML document into a particular category like 'Engineering'(Example: Engineering Document1)
9   Delete an XML document from particular category like 'Science'(Example: Science Document1)
10   Return all XML documents contain keyword like 'programming'(Example: programming)
11   EXIT
");

            string input = "";
            int inputNumber = 0;
            Category rootCategory = new Category("");
            string readlineInput = "";
            string arg1 = "", arg2 = "";

            while (true)
            {
                Console.Write("\nChoose Operation: ");
                input = Console.ReadLine();
                try
                {
                    inputNumber = Convert.ToInt32(input);
                    if (inputNumber < 1 || inputNumber > 11)
                        throw new Exception("Invalid Input");

                    if (inputNumber != 1 && rootCategory.CategoryName == "" && inputNumber != 11)
                        throw new Exception("Root Category Is not Created");

                    if (inputNumber == 1)
                    {
                        Console.Write("Enter Root Category Name: ");
                        readlineInput = Console.ReadLine();
                        if (readlineInput.Contains(' ') || char.IsNumber(readlineInput[0]))
                        {
                            throw new Exception("Invalid Input");
                        }

                        rootCategory = new Category(readlineInput);
                    }
                    else if (inputNumber == 2)
                    {
                        readlineInput = Console.ReadLine();
                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        CreateSubCategory(rootCategory, arg1, arg2);
                    }
                    else if (inputNumber == 3)
                    {
                        readlineInput = Console.ReadLine();
                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        CreateXMLDocForCategory(rootCategory, arg1, arg2);
                    }
                    else if (inputNumber == 4)
                    {
                        readlineInput = Console.ReadLine();
                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        rootCategory.InsertXMLDocumentContent(arg1, arg2);
                    }
                    else if (inputNumber == 5)
                    {
                        readlineInput = Console.ReadLine();
                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        rootCategory.DeleteXMLDocumentContent(arg1, arg2);
                    }
                    else if (inputNumber == 6)
                    {
                        rootCategory.DisplayAllElements();
                    }
                    else if (inputNumber == 7)
                    {
                        readlineInput = Console.ReadLine();
                        rootCategory.DisplayAllSubCategories(readlineInput);
                    }
                    else if (inputNumber == 8)
                    {
                        readlineInput = Console.ReadLine();

                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        rootCategory.InsertXMLDocumentIntoSubCategory(arg1, arg2);
                    }
                    else if (inputNumber == 9)
                    {
                        readlineInput = Console.ReadLine();

                        if (readlineInput.Split(new char[] { ' ' }).Count() != 2)
                            throw new Exception("Invalid Input");

                        arg1 = readlineInput.Split(new char[] { ' ' })[0];
                        arg2 = readlineInput.Split(new char[] { ' ' })[1];

                        rootCategory.DeleteXMLDocumentFromSubCategory(arg1, arg2);
                    }
                    else if (inputNumber == 10)
                    {
                        readlineInput = Console.ReadLine();
                        rootCategory.ReturnXMLDocumentsWithKeyword(readlineInput);
                    }
                    else if (inputNumber == 11)
                    {
                        System.Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write(@"
USAGE: (Choose Operation) Type Any of the Following Numbers:                                                        
1   Create Root Category(Recreate will delete previous root. Example: RootCategory)
2   Create a subcategory for a category(Example: RootCategory Category1)
3   Create an XML Document For A category(Example: RootCategory Document1)
4   Insert A keyword into an XML document(Example: Document1 Tree)
5   Delete A keyword from an XML document(Example: Document1 Tree)
6   Display All elements of root category
7   Display All subcategory under particular category like 'Database'(Example: Database)
8   Insert an XML document into a particular category like 'Engineering'(Example: Engineering Document1)
9   Delete an XML document from particular category like 'Science'(Example: Science Document1)
10   Return all XML documents contain keyword like 'programming'(Example: programming)
11   EXIT
                         ");
                }
            }
        }

        // assoc. with input 2
        public static void CreateSubCategory(Category rootCategory, string categoryName, string subCategoryName)
        {
            if (rootCategory.CategoryName == categoryName)
            {
                rootCategory.CreateCategory(new Category(subCategoryName));
                return;
            }
            else
            {
                foreach (Category cat in rootCategory.subCategoryList)
                {
                    CreateSubCategory(cat, categoryName, subCategoryName);
                }
            }
            //throw new Exception("Category Not Found");
        }

        public static void CreateXMLDocForCategory(Category rootCategory, string CategoryName, string XMLDocumentName)
        {
            if (rootCategory.CategoryName == CategoryName)
            {
                rootCategory.CreateXMLDocument(XMLDocumentName);
                return;
            }
            else
            {
                rootCategory.InsertXMLDocumentIntoSubCategory(CategoryName, XMLDocumentName);
            }
            //throw new Exception("Category Not Found");
        }

    }

}