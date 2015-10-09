import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DragonSharp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int lines = Integer.parseInt(scanner.nextLine());
        StringBuilder result = new StringBuilder();
        boolean wasFalse = false;
        for (int i = 0; i < lines; i++) {
            String line = scanner.nextLine();
            Matcher ifMatcher = Pattern.compile("if \\((?<num1>\\d+)(?<sign>==|<|>)(?<num2>\\d+)\\)(?: loop (?<loops>\\d+))* out \"(?<text>.+)\";").matcher(line);
            Matcher elseMatcher = Pattern.compile("else(?: loop (?<loops>\\d+))* out \"(?<text>.+)\";").matcher(line);

            boolean ifMatch = ifMatcher.find();
            boolean elseMatch = elseMatcher.find();

            if (!ifMatch && !elseMatch) {
                result = new StringBuilder(String.format("Compile time error @ line %d\n", i + 1));
                break;
            }

            if(ifMatch){
                wasFalse = false;
                int firstNumber = Integer.parseInt(ifMatcher.group("num1"));
                int secondNumber = Integer.parseInt(ifMatcher.group("num2"));
                String sign = ifMatcher.group("sign");

                if(isCorrect(firstNumber,secondNumber,sign)){
                    int loops = 1;
                    if(ifMatcher.group("loops") != null){
                        loops = Integer.parseInt(ifMatcher.group("loops"));
                    }

                    for (int j = 0; j < loops; j++) {
                        result.append(ifMatcher.group("text"));
                        result.append("\n");
                    }
                }
                else{
                    wasFalse = true;
                }
            }

            if(elseMatch && wasFalse){
                int loops = 1;
                if(elseMatcher.group("loops")!= null){
                    loops = Integer.parseInt(elseMatcher.group("loops"));
                }

                for (int j = 0; j <loops; j++) {
                    result.append(elseMatcher.group("text"));
                    result.append("\n");
                }
                wasFalse = false;
            }
        }

        System.out.println(result.toString());
    }

    private static boolean isCorrect(int a,int b, String sign){
        if(sign.equals("==") && a == b){
                return true;
        }
        if(sign.equals("<") && a < b){
            return true;
        }
        if(sign.equals(">") && a > b){
            return true;
        }
        return false;
    }
}
