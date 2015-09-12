package sort.bubble;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

//import org.apache.commons.lang.time.StopWatch;

public class SortingPseudocode {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        List<Integer> numbers =
                Arrays.asList(scan.nextLine().replace("[", "").replace("]", "").split(", "))
                .stream()
                .map(Integer::parseInt)
                .collect(Collectors.toList());



//        StopWatch stopWatch = new StopWatch();
//        stopWatch.start();

        boolean swapped = false;
        int indexOfLastUnsortedElement = numbers.size();
        do{
            swapped = false;
            for (int i = 1; i <indexOfLastUnsortedElement ; i++) {
                if(numbers.get(i - 1) > numbers.get(i)){
                    int temp = numbers.get(i-1);
                    numbers.set(i-1,numbers.get(i));
                    numbers.set(i, temp);
                    swapped = true;
                }
            }
            indexOfLastUnsortedElement = indexOfLastUnsortedElement-1;
        }while(swapped);

//        stopWatch.stop();
//        long time = stopWatch.getTime();

        System.out.println(numbers);
//        System.out.println(time/1000.0);
    }

    private static <T> void swap(ArrayList<T> list, int index1, int index2){
        T temp = list.get(index1);
        list.set(index1,list.get(index2));
        list.set(index2, temp);
    }
}