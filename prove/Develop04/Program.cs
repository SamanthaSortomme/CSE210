using System;

class Program
{
    static void Main(string[] args)
    {
        bool end = false;
        int selection;
        BreathingActivity activity1 = new BreathingActivity();
        ReflectingActivity activity2 = new ReflectingActivity();
        ListingActivity activity3 = new ListingActivity();

        Console.Clear();

        while (!end)
        {
            try
            {
                Console.Write("""
Menu:
Select from the following
1 Breathing
2 Reflecting
3 Writing  
4 Exit

""");
                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        {
                            activity1.StartActivity();
                            break;
                        }

                    case 2:
                        {
                            activity2.StartActivity();
                            break;
                        }

                    case 3:
                        {
                            activity3.StartActivity();
                            break;
                        }

                    case 4:
                        {
                            end = true;
                            break;
                        }

                    default:
                        {
                            Console.Write($"\nPlease enter a number within the specified range.\n\n");
                            break;
                        }
                }
            }


            catch (FormatException e)
            {
                Console.Write(e.Message);
            }



        }
    }
}