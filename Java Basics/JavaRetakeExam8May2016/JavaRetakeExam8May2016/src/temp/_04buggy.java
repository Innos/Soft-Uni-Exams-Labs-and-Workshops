package temp;

import java.math.BigDecimal;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class _04buggy {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String line = scanner.nextLine();
        String pattern = "^([a-zA-Z]+);(\\-?\\d+);(\\-?\\d+|-?\\d+\\.\\d*);([a-zA-Z]+)$";
        Pattern r = Pattern.compile(pattern);
        TreeSet<String> names = new TreeSet<>();
        LinkedHashMap<String,Team> teams = new LinkedHashMap<>();


        while (!line.equals("Pishi kuf i da si hodim")) {
            Matcher m = r.matcher(line);
            if (m.find()) {
                if (!names.contains(m.group(1))) {
                    Employee employee = new Employee(m.group(1), Integer.parseInt(m.group(2)), Double.parseDouble(m.group(3)));
                    if (!teams.containsKey(m.group(4))) {
                        teams.put(m.group(4),new Team(m.group(4)));
                    }
                    teams.get(m.group(4)).employees.add(employee);
                    names.add(m.group(1));
                }
            }
            line = scanner.nextLine();
        }

        teams = teams.entrySet().stream().sorted(new Comparator<Map.Entry<String, Team>>() {
            @Override
            public int compare(Map.Entry<String, Team> o1, Map.Entry<String, Team> o2) {
                BigDecimal team1Money = BigDecimal.ZERO;
                BigDecimal team2Money = BigDecimal.ZERO;

                for (Employee employee : o1.getValue().employees) {
                    team1Money = team1Money.add(employee.monthlyPayment);
                }
                for (Employee employee : o2.getValue().employees) {
                    team2Money = team2Money.add(employee.monthlyPayment);
                }

                return -team1Money.compareTo(team2Money);
            }
        }).collect(Collectors.toMap(y->y.getKey(),x->x.getValue(),(s, a) -> a,LinkedHashMap::new));
        for (Map.Entry<String, Team> team : teams.entrySet()) {
            System.out.println("Team - " + team.getKey());
            for (Employee employee : team.getValue().employees) {
                System.out.println(employee);
            }
        }
    }

}

class teamComparator implements Comparator<Map.Entry<String,Team>>{

    @Override
    public int compare(Map.Entry<String, Team> o1, Map.Entry<String, Team> o2) {
        BigDecimal team1Money = BigDecimal.ZERO;
        BigDecimal team2Money = BigDecimal.ZERO;

        for (Employee employee : o1.getValue().employees) {
            team1Money = team1Money.add(employee.monthlyPayment);
        }
        for (Employee employee : o2.getValue().employees) {
            team2Money = team2Money.add(employee.monthlyPayment);
        }

        return -team1Money.compareTo(team2Money);
    }
}

class Team implements Comparable<Team>{

    public String name;
    public TreeSet<Employee> employees;

    public Team(String name){
        this.name = name;
        this.employees = new TreeSet<>();
    }

    @Override
    public int compareTo(Team o) {
        BigDecimal team1Money = BigDecimal.ZERO;
        BigDecimal team2Money = BigDecimal.ZERO;

        for (Employee employee : this.employees) {
            team1Money = team1Money.add(employee.monthlyPayment);
        }
        for (Employee employee : o.employees) {
            team2Money = team2Money.add(employee.monthlyPayment);
        }

        return -team1Money.compareTo(team2Money);
    }
}

class Employee implements Comparable<Employee> {
    public int workHours;
    public double dailySalary;
    //public double dailyIncome;
    public BigDecimal dailyIncome;
    public BigDecimal monthlyPayment;
    public String name;

    public Employee(String name, int workHours, double dailySalary) {
        this.name = name;
        this.workHours = workHours;
        this.dailySalary = dailySalary;
        //this.dailyIncome = (dailySalary*workHours)/ 24;
        this.dailyIncome = (new BigDecimal(dailySalary).multiply(new BigDecimal(workHours))).divide(new BigDecimal(24),12,BigDecimal.ROUND_HALF_DOWN);
        this.monthlyPayment = this.dailyIncome.multiply(new BigDecimal(30));
    }

    @Override
    public String toString() {
//        return String.format("$$$%s - %d - %.6f", this.name, this.workHours, this.dailyIncome);
        return String.format("$$$%s - %d - %s", this.name, this.workHours, this.dailyIncome.setScale(6,BigDecimal.ROUND_HALF_UP).toPlainString());
    }

    @Override
    public int compareTo(Employee o) {
        int result = -Integer.compare(this.workHours, o.workHours);
        if (result == 0) {
            result = -this.dailyIncome.compareTo(o.dailyIncome);
            //result = -Double.compare(this.dailyIncome,o.dailyIncome);
        }
        if (result == 0) {
            result = this.name.compareTo(o.name);
        }
        return result;
    }
}