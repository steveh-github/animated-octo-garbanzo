using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
    class Program
    {

        //List<Mast> masts = new List<Mast>();

        static string[] GetInputCoordinates()
        {
            try
            {
                //Get user input
                Console.WriteLine("Enter list of coordinates in format 50,50 54,79 90,100 etc");
                string strInput = Console.ReadLine();
                return strInput.Split(' ');

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        static void CompareDistances()
            
        {
            try
            {

            

            // get the user input string
            string[] Coordinates = GetInputCoordinates();


            // split the string and create Mast objects for each pair of coordinates
            List<Mast> masts = new List<Mast>();
            for (int i = 0; i < Coordinates.Length; i++)
            {
                string[] mast = Coordinates[i].Split(',');
                Mast m = new Mast(Convert.ToInt32(mast[0]), Convert.ToInt32(mast[1]));
                masts.Add(m);
                    
             }

            
            // Now compare the distance for all possible combinations of mask objects
            // REM if we have checked X,Y we dont need to check Y,X 

            
            // This is for the points we have already checked.
            List<Point> points = new List<Point>();
            
            double distance = 0;
            double closest = -1;
            string output1 = "";
            string output2 = "";

           
            for (int i = 0; i < masts.Count; i++)
            {
               
                for (int j = 0; j < masts.Count; j++)
                {

                    bool skip = false;

                    if (i == j)
                    {
                        // skip the loop processing if we are comparing the same Mast object
                        continue;
                    }


                    // skip if have already comapred the point in the other direction
                    // ie dont compare Y,X if we have already compared X,Y
                    foreach (Point myp in points)
                    {
                       if(myp.x==j && myp.y==i)
                        {
                            skip = true;
                            continue;
                        }
                    }
                    
                    if (skip)
                    {
                        continue;
                    }

                    
                    distance = BLL.GetDistance(masts[i], masts[j]);

                    // Add these for debugging
                  //  Console.WriteLine("index {0} {1} distance {2}", i, j,distance);
                    

                    if (closest == -1)
                    {
                        closest = distance;
                        output1 = string.Format("Index of closest masts: {0} {1}", i, j);
                        output2 = "Coordinates of closest masts: " + masts[i].print() + masts[j].print();

                    }
                    else if (distance < closest)
                    {
                        closest = distance;
                        output1 = string.Format("Index of closest masts: {0} {1}", i, j);
                        output2 = "Coordinates of closest masts: " + masts[i].print() + masts[j].print();
                    }


                    // keep track of the points we have compared
                    Point p = new Point(i,j);
                    points.Add(p);

                }
                
            }

            /**
             Display the output as per the spec
            **/
            Console.WriteLine(output1);
            Console.WriteLine(output2);
            Console.WriteLine("Distance of closest masts: {0}", closest);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured , please check the input");
                //throw ex;
            }


        }

        static void Main(string[] args)
        {
            try
            {
                CompareDistances();
            }
            catch (Exception)
            {
                throw;

            }
            
        }
    }
}
