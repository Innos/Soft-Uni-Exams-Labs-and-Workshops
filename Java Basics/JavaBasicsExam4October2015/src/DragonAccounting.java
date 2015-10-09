import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonAccounting {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        BigDecimal capital = new BigDecimal(scanner.nextLine());
        List<EmployeeGroup> employees = new ArrayList<>();
        int day = 0;
        boolean isBankrupt = false;
        String line = scanner.nextLine();
        while (!line.equals("END")) {
            String[] parameters = line.split(";");
            long hiredEmployees = Long.parseLong(parameters[0]);
            long firedEmployees = Long.parseLong(parameters[1]);
            BigDecimal salary = new BigDecimal(parameters[2]);



            //hire employees
            employees.add(new EmployeeGroup(hiredEmployees, salary, day));

            day++;

            //check for raise
            if(day > 364){
                for (int i = 0; i < employees.size(); i++) {
                    if ((day - employees.get(i).dayStarted) % 365 == 0) {
                        employees.get(i).salary = employees.get(i).salary.multiply(new BigDecimal(1.006));
                        employees.get(i).dailySalary = employees.get(i).salary.divide(new BigDecimal(30),9,RoundingMode.UP).setScale(7, RoundingMode.DOWN);
                    }
                }
            }

            //give salaries
            if (day % 30 == 0) {
                for (int i = 0; i < employees.size(); i++) {
                    capital = capital.subtract(calculateSalary(employees.get(i), day));
                }
            }

            //fire employees
            for (int i = 0; i < employees.size(); i++) {
                if (firedEmployees > employees.get(i).count) {
                    firedEmployees -= employees.get(i).count;
                    employees.remove(0);
                    i--;
                } else if (firedEmployees < employees.get(i).count) {
                    employees.get(i).count -= firedEmployees;
                    break;
                } else if (firedEmployees == employees.get(i).count) {
                    employees.remove(0);
                    break;
                }
            }

            //check for extras
            for (int i = parameters.length - 1; i > 2; i--) {
                String[] subParams = parameters[i].split(":");
                String reason = subParams[0];
                BigDecimal extra = new BigDecimal(subParams[1]);
                if (reason.equals("Previous years deficit") || reason.equals("Machines") || reason.equals("Taxes")) {
                    capital = capital.subtract(extra);
                }
                if(reason.equals("Product development") || reason.equals("Unconditional funding")){
                    capital = capital.add(extra);
                }
            }

            //check for bankruptcy
            if(capital.compareTo(BigDecimal.ZERO)<= 0){
                isBankrupt = true;
                break;
            }
            line = scanner.nextLine();
        }
        if(isBankrupt){
            System.out.printf("BANKRUPTCY: %s",capital.abs().setScale(4,RoundingMode.DOWN).toPlainString());
        }else{
            System.out.printf("%d %s",employees.stream().mapToLong(x->x.count).sum(),capital.setScale(4,RoundingMode.DOWN).toPlainString());
        }
    }

    private static BigDecimal calculateSalary(EmployeeGroup employeeGroup, int day) {
        int daysWorked = day - employeeGroup.dayStarted > 30 ? 30 : day - employeeGroup.dayStarted;
        BigDecimal salary = employeeGroup.dailySalary
                .multiply(new BigDecimal(employeeGroup.count))
                .multiply(new BigDecimal(daysWorked));

        return salary;
    }


}

class EmployeeGroup {
    public long count;
    public BigDecimal dailySalary;
    public BigDecimal salary;
    public int dayStarted;

    public EmployeeGroup(long count, BigDecimal salary, int dayStarted) {
        this.count = count;
        this.salary = salary;
        this.dailySalary = salary.divide(new BigDecimal(30),9,RoundingMode.UP).setScale(7,RoundingMode.DOWN);
        this.dayStarted = dayStarted;
    }
}
