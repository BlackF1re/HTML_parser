using System;
using System.Linq;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace HTML_parser;

public class Program
{
    public static void Main()
    {
        var url = "https://studyintomsk.ru/programs-main/";
        var web = new HtmlWeb();
        var doc = web.Load(url);
        /*
        /html/body/div[2]/div/div[3]/div[5]/select - программы подготовки
        /html/body/div[3]/div[3] - карточки со сдвигами
        /html/body/div[2]/div/div[3]/div[3]/select - вузы
        /html/body/div[2]/div/div[3]/div[1]/select - уровни
        /html/body/div[2]/div/div[3]/div[4]/select - языки
        */
        var value = doc.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div/div/div/div/div");

        string noTabsDoc = string.Empty;
        foreach (var item in value)
        {
            noTabsDoc += item.InnerText; //node is single row?
        }

        noTabsDoc = noTabsDoc.Replace("\t", "\n");

        List<string> cardsList = new(); //лист с правильными данными, идущими подряд

        cardsList = noTabsDoc.Split('\n').ToList(); //построчная запись в лист

        #region data cleaning
        string itemToRemove = "\n";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Уровень обучения";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Форма обучения";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Код программы ";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Продолжительность";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Степень или квалификация";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Язык обучения";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Куратор";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "за год обучения";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Поступить";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Нет подходящей программы?";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Напишите нам об этом и мы придумаем для вас индивидуальное  решение.";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = "Получить решение";
        cardsList.RemoveAll(x => x == itemToRemove);

        itemToRemove = string.Empty;
        cardsList.RemoveAll(x => x == itemToRemove);
        #endregion

        List<Card> cards = new(); //набор карточек (классов)
        /*
        Всего строк: 6501
        Строк на одну карточку: 13
        Карточек: 500
        */
        int Id = 0;
        string UniversityName;
        string ProgramName;
        string ProgramName2;//what?
        string Level;
        string ProgramCode;
        string StudyForm;
        string Duration;
        string Qualification; //same as Level
        string StudyLang;
        string Curator;
        string PhoneNumber;
        string Email;
        string Cost;

        int id = 0;
        int row1 = 0;
        int row2 = 1;
        int row3 = 2;
        int row4 = 3;
        int row5 = 4;
        int row6 = 5;
        int row7 = 6;
        int row8 = 7;
        int row9 = 8;
        int row10 = 9;
        int row11 = 10;
        int row12 = 11;
        int row13 = 12;

        int cardCounter = 0;
        int cardsTotalRows = cardsList.Count/13;

        foreach (string line in cardsList)
        {
            cards.Add(new Card(Id = id, UniversityName = cardsList[row1], ProgramName = cardsList[row2], ProgramName2 = cardsList[row3],
                                Level = cardsList[row4], ProgramCode = cardsList[row5], StudyForm = cardsList[row6], Duration = cardsList[row7],
                                Qualification = cardsList[row8], StudyLang = cardsList[row9], Curator = cardsList[row10], PhoneNumber = cardsList[row11], 
                                Email = cardsList[row12], Cost = cardsList[row13]));
            id ++;

            //переход на строки для следующей карточки
            row1 += 13;
            row2 += 13;
            row3 += 13;
            row4 += 13;
            row5 += 13;
            row6 += 13;
            row7 += 13;
            row8 += 13;
            row9 += 13;
            row10 += 13;
            row11 += 13;
            row12 += 13;
            row13 += 13;

            cardCounter ++;
            if (cardCounter == cardsTotalRows)
                break;
        }

        for (int i = 0; i < cardsList.Count; i++)
        {
            Console.WriteLine(cardsList[i]);
        }

        //запись правильных данных в файл
        string path = "parsing result.prs";
        StreamWriter parsingResultWriter = new(path);

        foreach (string line in cardsList)
        {
            parsingResultWriter.WriteLine(line);
        }
        parsingResultWriter.Close();
        Console.WriteLine("Parsing is done. Press any key to exit");
    }

}