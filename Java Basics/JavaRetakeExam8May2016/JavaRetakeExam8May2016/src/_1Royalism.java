import org.omg.CORBA.Environment;

import java.util.ArrayList;
import java.util.Scanner;

public class _1Royalism {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] people = scanner.nextLine().split(" ");
        ArrayList<String> royalists = new ArrayList<String>();
        ArrayList<String> common = new ArrayList<String>();
        int letterPPosition = 'R' - 'A' + 1;

        for (String person : people) {
            int position = CalculateLetter(person);
            if(position == letterPPosition){
                royalists.add(person);
            }
            else{
                common.add(person);
            }
        }

        if(royalists.size() < common.size()){
            System.out.println(String.join(System.lineSeparator(),common));
            System.out.println("Royalism, Declined!");
        }else{
            System.out.println("Royalists - " + royalists.size());
            System.out.println(String.join(System.lineSeparator(),royalists));
            System.out.println("All hail Royal!");
        }
    }

    private static int CalculateLetter(String person){
        int code = 0;
        for(int i = 0; i < person.length();i++){
            code += person.charAt(i);
        }

        code = code % 26;
        return code;
    }

}
