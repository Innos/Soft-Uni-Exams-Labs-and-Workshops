import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class _04Ivo {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		
		ArrayList<String> allEmployees = new ArrayList<>();
		LinkedHashMap<String, LinkedHashMap<String, Double[]>> employeesByTeamDatabase = new LinkedHashMap<>();
		
		//Pattern : ^([a-zA-Z]+)\;(\d+)\;(\d+\.?\d+)\;([a-zA-Z]+)$
		String stringPattern = "^([a-zA-Z]+)\\;(\\-?\\d+)\\;(\\-?\\d+\\.?\\d*)\\;([a-zA-Z]+)$";
		
		Pattern regexPattern = Pattern.compile(stringPattern);
		
		String inputLine = scanner.nextLine();
		
		while(!inputLine.equals("Pishi kuf i da si hodim")) {
			
			Matcher matcher = regexPattern.matcher(inputLine);
			
			if(matcher.find()) {
				
				String teamName = matcher.group(4);
				String employeeName = matcher.group(1);
				Double workHoursPerDay = Double.parseDouble(matcher.group(2));
				Double dailyPayment = Double.parseDouble(matcher.group(3));
				
				if(!allEmployees.contains(employeeName)) {
					if(employeesByTeamDatabase.containsKey(teamName)) {
						Double[] employeeCharacteristics = new Double[] { workHoursPerDay, dailyPayment };
						
						LinkedHashMap<String, Double[]> currentEmployees = employeesByTeamDatabase.get(teamName);
						currentEmployees.put(employeeName, employeeCharacteristics);
					}
					else {
						Double[] employeeCharacteristics = new Double[] { workHoursPerDay, dailyPayment };
						
						LinkedHashMap<String, Double[]> currentEmployees = new LinkedHashMap<>();
						currentEmployees.put(employeeName, employeeCharacteristics);
						
						employeesByTeamDatabase.put(teamName, currentEmployees);
					}
					
					allEmployees.add(employeeName);
				}
			}
			
			inputLine = scanner.nextLine();
		}
		
		LinkedHashMap<String, LinkedHashMap<String, Double[]>> sortedEmployeeDatabase = 
				employeesByTeamDatabase
				.entrySet()
				.stream()
				.sorted(
						(firstTeam, secondTeam) -> {
							Double firstTeamMoney = 
									firstTeam
									.getValue()
									.values()
									.stream()
									.collect(Collectors.summingDouble(employeeCredentials -> ((employeeCredentials[0].doubleValue() * employeeCredentials[1].doubleValue()) / 24) * 30));
							
							Double secondTeamMoney = 
									secondTeam
									.getValue()
									.values()
									.stream()
									.collect(Collectors.summingDouble(employeeCredentials -> ((employeeCredentials[0].doubleValue() * employeeCredentials[1].doubleValue()) / 24) * 30));
							
							Integer result = secondTeamMoney.compareTo(firstTeamMoney);
							return result;
						})
				.collect(
						Collectors.toMap(
								Map.Entry::getKey,
								Map.Entry::getValue,
								(x, y) -> { throw new AssertionError(); },
								LinkedHashMap::new
								)
						);
		
		String employeeOutputPadding = "$$$";
		
		for (Map.Entry<String, LinkedHashMap<String, Double[]>> currentTeam : sortedEmployeeDatabase.entrySet()) {

			double t1 = currentTeam.getValue()
					.values()
					.stream()
					.collect(Collectors.summingDouble(employeeCredentials -> ((employeeCredentials[0].doubleValue() * employeeCredentials[1].doubleValue()) / 24) * 30));

			System.out.println(String.format("Team - %s - %.16f", currentTeam.getKey(),t1));
			
			LinkedHashMap<String, Double[]> sortedEmployees = 
					currentTeam
					.getValue()
					.entrySet()
					.stream()
					.sorted(
							(firstEmployee, secondEmployee) -> {
								
								Integer result = secondEmployee.getValue()[0].compareTo(firstEmployee.getValue()[0]);
								
								if(result.equals(0)) {
									Double firstEmployeeDailyIncome = ((firstEmployee.getValue()[0] * firstEmployee.getValue()[1]) / 24);
									Double secondEmployeeDailyIncome = ((secondEmployee.getValue()[0] * secondEmployee.getValue()[1]) / 24);
									
									result = secondEmployeeDailyIncome.compareTo(firstEmployeeDailyIncome);
									
									if(result.equals(0)) {
										result = firstEmployee.getKey().compareTo(secondEmployee.getKey());
									}
								}
								
								return result;
							})
					.collect(
							Collectors.toMap(
									Map.Entry::getKey,
									Map.Entry::getValue,
									(x, y) -> { throw new AssertionError(); },
									LinkedHashMap::new
									)
							);
			
			for (Map.Entry<String, Double[]> currentEmployee : sortedEmployees.entrySet()) {
				System.out.println(
						String.format("%s%s - %s - %f", 
						employeeOutputPadding, 
						currentEmployee.getKey(), 
						currentEmployee.getValue()[0].intValue(), 
						(currentEmployee.getValue()[0] * currentEmployee.getValue()[1].doubleValue()) / 24));
			}
		}
	}
}
