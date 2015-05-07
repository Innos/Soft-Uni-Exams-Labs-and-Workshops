using System;

class Sunglasses
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        for (int i = 0; i < height; i++)
        {
            if (i == 0 || i == height - 1)
            {
                string emptySpace = new string(' ', height);
                string frame = new string('*', height * 2);
                Console.WriteLine("{0}{1}{0}",frame,emptySpace);
            }
            else
            {
                string lense = new string('/', (height * 2) - 2);
                string midFrame = String.Format("{0}{1}{0}", '*', lense);
                string connection = new string(' ', height);
                if (i == height/2)
                {
                    connection = new string('|', height);

                }
                Console.WriteLine("{0}{1}{0}",midFrame,connection);
            }
        }
    }
}

