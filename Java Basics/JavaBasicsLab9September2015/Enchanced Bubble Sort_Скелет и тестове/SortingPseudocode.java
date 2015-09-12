package sort.bubble;


import java.util.ArrayList;
import java.util.Scanner;

//import org.apache.commons.lang.time.StopWatch;

public class SortingPseudocode {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbers = scan.nextLine().replace("[", "").replace("]", "").split(", ");
        ArrayList<Integer> numbersArr = new ArrayList<Integer>();

        //TODO: Parse the numbers and add them to the list

//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();

        //TODO: Write the sorting algorithm that you use for sorting the List's elements

//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbersArr);
//        System.out.println(time/1000.0);
    }
}