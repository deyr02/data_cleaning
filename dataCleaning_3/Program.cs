using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Collections;
using CsvHelper;

namespace dataCleaning_3
{
    class Program
    {
        int good = 0;
        int bad = 0;
        int terrible = 0;
        int netrul = 0;
        int excellent = 0;
        public string getcounters()
        {
            return "Terrible " + terrible.ToString() +"\n" +
                "Bad " + bad.ToString() + "\n" +
                "Netural " + netrul.ToString() + "\n" +
                "Good " + good.ToString() + "\n" +
                "Excellent " + excellent.ToString();
        }
        public ArrayList ReadFile( TextFieldParser filepath)
        {
            ArrayList list = new ArrayList();
          
            using (TextFieldParser parser = filepath)
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string Data = parser.ReadLine();
                    list.Add(Data);
                  //  Console.WriteLine(Data);
                  //  Console.ReadKey();
                  

                }
              
            }
            return list;
        }
        public void write_files(StreamWriter filepath, ArrayList list)
        {
            using (StreamWriter sw = filepath)
            {
                // var Writer = new CsvWriter(sw);
                //  Writer.WriteHeader(typeof(string));
                for (int x = 0; x < list.Count; x++)
                {

                    string M = list[x].ToString();
                    sw.WriteLine(M);
                }
                   
            }
        }

        private string romove_text_get_number(string data)
        {
            string row = data;
            string return_value = "";
            if (data == "null")
            {
                return_value = data;
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (char.IsDigit(data[i]))
                    {
                        return_value += data[i];
                    }
                }
            }
            return return_value;
        }
       
        public int awards(string details1, string details2, string details3, string details4)
        {

             int  num = 96;
            if (details1.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                num = num + 1;
            }
            if (details2.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                num = num + 1;
            }
            if (details3.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                num = num + 1;
            }
            if (details4.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                num = num + 1;
            }
            return num;
        }
        public double metacritic_ranking(string details)
        {
            double num = 0;
            if (!(details.Equals("?", StringComparison.InvariantCultureIgnoreCase))){
                num = 0.50;
            }
            return num;
        }
        public double doublScore(String num)
        {
            Double r = 0.0;
            if (!(num.Equals("?", StringComparison.InvariantCultureIgnoreCase)))
            {
                double x = Convert.ToDouble(num);

                r = x * 10;
            }
           
            return r;
        }
        public int singleScore( String num)
        {
            int r = 0;
            if (!((num.Equals("?", StringComparison.InvariantCultureIgnoreCase) || (num.Equals("'?'", StringComparison.InvariantCultureIgnoreCase)))))
            {
                int x = Convert.ToInt32(num);

                r = x;
            }

            return r;
            /*
            double r = 0;
            r = num / 100;
            
            if ((num <= 55) || (num > 0))
            {
                r = num / 100;
            }
            else if ((num <= 70) || (num > 55))
            {
                r = num / 100;
            }
            else if ((num <= 80) || (num > 70))
            {
                r =num / 100;
            }
            else if ((num <= 90) || (num > 80))
            {
                r = num / 100;
            }
            else if ((num <= 100) || (num > 90))
            {
                r = num / 100;
            }*/
          
        }
        public string overallRating(double num)
        {
            string r = "";

            if ((num <= 400) && (num > 0))
            {
                r = "Terrible";
                terrible++;
            }
            else if ((num <= 460) && (num > 400))
            {
                r = "Bad";
                bad++;
            }
            else if ((num <= 510) && (num > 460))
            {
                r = "Neutral";
                netrul++;
            }
            else if((num <= 530) && (num > 510))
            {
                r = "Good";
                good++;
            }
            else
            if ((num > 530))
            {
                r = "Excellent";
                excellent++;
            }
            return r;
        }
        
        static void Main(string[] args)
        {
            Program F = new Program();
            // string v = "D:\My Study\BCS S5\Data Mining\Assignment - 1\dataCleaning_3\dataCleaning_3\step_2.csv";
            /* ArrayList c = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\dataCleaning_3\step_2.csv"));
                 ArrayList newlist = new ArrayList();
                 for (int i =0; i<c.Count; i++)
                 {
                     if (i > 0)
                     {
                         string v = c[i].ToString();

                         string[] D = v.Split(',');
                         string x = D[20];
                         string y = F.romove_text_get_number(x);
                         newlist.Add(y);

                         Console.WriteLine(y);
                         Console.WriteLine("\n");

                     }

                 }


                 Console.ReadKey();

                 using(StreamWriter sw = new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\dataCleaning_3\new_2_critic.csv"))
                 {
                    // var Writer = new CsvWriter(sw);
                     //  Writer.WriteHeader(typeof(string));
                     for (int x = 0; x < newlist.Count; x++)
                     {
                         // Writer.WriteRecord(newlist[x].ToString());

                         string M = string.Format("{0}", newlist[x].ToString()) + "," + x.ToString();
                         sw.WriteLine(M);
                         //Console.WriteLine(newlist[x]);
                     }
                 }
                 */
            /*ArrayList Location = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\dataCleaning_3\location_3_1.csv"));
            ArrayList new_location = new ArrayList();
            for (int i= 0; i< Location.Count; i++)
            {
                string l1 = "";
                string l2 = "";
                string loc = Location[i].ToString();
                if ((loc == "null")|| (loc == "company contact information")|| (loc == "Color"))
                {
                    l1 = "null";
                    l2 = "null";
                }
                else
                {
                    string[] data = loc.Split(',');
                    if (data.Length ==1)
                    {
                        l1 = data[0];
                        l2 = "null";
                    }
                    else if (data.Length == 2)
                    {
                        l1 = data[0];
                        l2 = data[1];
                    }
                    else if (data.Length == 3)
                    {
                        l1 = data[0];
                        l2 = data[1];
                    }
                }
                string p = l1 + "," + l2;
                new_location.Add(p);
                Console.WriteLine(Location[i]);
            }
            using (StreamWriter sw = new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\dataCleaning_3\location_3_2.csv"))
            {
                // var Writer = new CsvWriter(sw);
                //  Writer.WriteHeader(typeof(string));
                for (int x = 0; x < new_location.Count; x++)
                {
                    // Writer.WriteRecord(newlist[x].ToString());

                    string M = new_location[x].ToString();
                    sw.WriteLine(M);
                    //Console.WriteLine(newlist[x]);
                }
            }*/

            /*  ArrayList Imbd = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\Fresh Start\movies_11.csv"));

              ArrayList new_Imdb = new ArrayList();

              double high = 0;
              new_Imdb.Add(Imbd[0].ToString());
              string title = "";
              string num = "";

              String[] attributes = Imbd[0].ToString().Split(',');

              for(int i =0; i<attributes.Length; i++)
              {
                  Console.WriteLine("Inded : " + i + " AttributeName :" + attributes[i].ToString());
              }

              ///looping through the whole arrayList
              ///double Result = 0;
              int awardsResult = 0;
              double ImdbSocer = 0;
              double MetaScore = 0;
              double UserScore = 0;
              double tomato_score = 0;
              double tomato_audience = 0;
              double Result = 0;
              for (int i =0; i< Imbd.Count; i++)
              {
                 if(i != 0)
                  {
                      string data = Imbd[i].ToString();
                      string[] details = data.Split(',');

                      for (int j = 0; j < details.Length; j++)
                      {

                          awardsResult = F.awards(details[22], details[23], details[24], details[25]);
                          ImdbSocer = F.doublScore(details[29]);
                          MetaScore = F.singleScore(details[34]);
                           UserScore = F.doublScore(details[36]);
                          tomato_score = F.singleScore(details[38].ToString());
                          tomato_audience = F.singleScore(details[40].ToString());



                      }
                      Result = awardsResult + ImdbSocer + MetaScore + UserScore + tomato_audience + tomato_score;
                      string d = F.overallRating(Result);
                      string a = Imbd[i].ToString();
                      string final = a + "," + d;
                      new_Imdb.Add(final);
                      Console.WriteLine(d);
                      F.write_files(new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\Fresh Start\newWIthoverallrating.csv"), new_Imdb);

                  }
              }
              string s = F.getcounters();
              Console.WriteLine(s);

             /*
              for (int i =0; i< Imbd.Count; i++)
              {
                 if (i != 0)
                  {
                      string[] x = Imbd[i].ToString().Split(',');
                      double Nominated_academy = 0;
                      double Won_academy = 0;
                      double nominated_globe = 0;
                      double won_globe = 0;
                      Double imbd_score = 0.0;
                      double Metacritic_ranking = 0;
                      double meatacore = 0.0;
                      double meta_user_score = 0;
                      Double t_score = 0;
                      Double t_aud = 0;
                      double prof = 0;

                      for (int j = 0; j < x.Length; j++)
                      {
                          // Console.WriteLine(x[j]);
                          string v = x[j].ToString();
                        /*if (j ==22)
                          {
                              Nominated_academy = F.awards(v) - 0.15;
                          }
                         else if (j == 23)
                          {
                              Won_academy = F.awards(v) - 0.10;

                          }
                         else if (j == 24)
                          {
                              nominated_globe = F.awards(v);
                          }
                         else if (j ==25)
                          {
                              won_globe = F.awards(v);
                          }
                          else if (j == 29)
                          {
                              try
                              {
                                  imbd_score = F.doublScore(Convert.ToDouble(v));
                              }
                              catch (FormatException)
                              {
                                  imbd_score = 0;
                              }


                          }
                         else if (j == 34)

                          {
                              try
                              {
                                  Metacritic_ranking = F.metacritic_ranking(v);
                              }
                              catch (FormatException)
                              {
                                  Metacritic_ranking = 0;
                              }


                          }
                         else if (j == 37)
                          {

                              try
                              {
                                  meatacore = F.singleScore(Convert.ToInt32(v));
                              }
                              catch (FormatException)
                              {
                                  meatacore = 0;
                              }


                          }
                         else if(j == 42)
                          {
                              try
                              {
                                  meta_user_score = F.doublScore(Convert.ToDouble(v));
                              }
                              catch (FormatException)
                              {
                                  meta_user_score = 0;
                              }



                          }
                         else if (j == 44)
                          {
                              try
                              {
                                  t_score = F.singleScore(Convert.ToInt32(v));
                              }
                              catch (FormatException)
                              {
                                  meatacore = 0;
                              }



                          }
                         else if(j == 48)
                          {
                              try
                              {
                                  t_aud = F.singleScore(Convert.ToInt32(v));
                              }
                              catch (FormatException)
                              {

                                  t_aud = 0;
                              }


                          }
                         else if(j == 49)
                          {
                              prof = F.awards(v);
                          }


                      }

                      Double total = Nominated_academy + Won_academy + nominated_globe + won_globe + imbd_score +
                       +Metacritic_ranking
                       + meatacore
                       + meta_user_score
                       + t_score
                       + t_aud
                       + prof;
                      if(total > high)
                      {
                          high = total;
                      }
                      Console.WriteLine("tatal "+ total.ToString());
                      string result = F.overallRating(total);
                      Console.WriteLine(result);
                      string a = Imbd[i].ToString();
                      string final = a + "," + result;
                      new_Imdb.Add(final);

                  }


              }
              Console.WriteLine("hight " + high.ToString());
              Console.WriteLine("tatal " + F.getcounters());
              Console.WriteLine();
              F.write_files(new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\movies_12.csv"), new_Imdb);
              // F.write_files(new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\dataCleaning_3\new_metacritic.csv"), new_metacritic);
              Console.WriteLine(Imbd.Count.ToString());
              */

            /*
                        ArrayList Matches = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\matches1.csv"));
                        ArrayList Delevieries = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\dataCleaning_3\deliveries1.csv"));
                        ArrayList new_location = new ArrayList();
                        string heading = "";
                        string heading1 = "";
                        for (int i = 0; i < Matches.Count; i++)
                        {
                            if(i == 0)
                            {
                                heading = Matches[i].ToString();
                            }
                            string data = Matches[i].ToString();
                            string[] details = data.Split(',');
                            string matchid = details[0];
                            for(int j =0; j< Delevieries.Count; j++)
                            {
                                if (j == 0)
                                {
                                    heading1 = Delevieries[j].ToString();
                                    if(i == 0)
                                    {
                                        string h = heading +"," + heading1;
                                        new_location.Add(h);
                                    }
                                }
                                string data1 = Delevieries[j].ToString();
                                string[] details1 = data1.Split(',');
                                string deliveryid = details1[0];

                                if (matchid == deliveryid)
                                {
                                    string row = data + "," + data1;
                                    new_location.Add(row);

                                }
                            }

                        }


                        F.write_files(new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\merge_file.csv"), new_location);*/
            ArrayList N = new ArrayList();
            ArrayList dataset = F.ReadFile(new TextFieldParser(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\merge_file.csv"));
            for(int i  = 0; i< dataset.Count; i++)
            {
                if (i == 0)
                {
                    N.Add(dataset[0].ToString());
                }
                string data = dataset[i].ToString();
                string [] d = data.Split(',');
                string toss_winer = d[6].ToString();
                string toos_decision = d[7].ToString();
                string match_result = d[8].ToString();
                string winner = d[10].ToString();

                string result = "";
               
                if (i != 0)
                {
                    if (match_result == "normal")
                    {
                        if (toos_decision == "field")
                        {
                            if (toss_winer == winner)
                            {
                                result = dataset[i].ToString() + "," + "Excellent";
                                N.Add(result);
                            }
                            else
                            {
                                result = dataset[i].ToString() + "," + "Bad";
                                N.Add(result);
                            }
                        }
                        else if (toos_decision == "bat")
                        {

                            if (toss_winer == winner)
                            {
                                result = dataset[i].ToString() + "," + "Good";
                                N.Add(result);
                            }
                            else
                            {
                                result = dataset[i].ToString() + "," + "Worst";
                                N.Add(result);
                            }
                        }
                    }
                    else
                    {
                        result = dataset[i].ToString() + "," + "Neutral";
                        N.Add(result);
                    }
                }
             
               
            }
            F.write_files(new StreamWriter(@"D:\My Study\BCS S5\Data Mining\Assignment -1\New2017 s2\merge_file2.csv"), N);
            Console.ReadKey();

        }
    }
}
