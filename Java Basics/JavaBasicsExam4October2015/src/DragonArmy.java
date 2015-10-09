import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class DragonArmy {
    public static void main(String[] args) {
        LinkedHashMap<String,TreeMap<String,Dragon>> dragons = new LinkedHashMap<>();
        Scanner scanner = new Scanner(System.in);
        int ammount = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < ammount; i++) {
            String[] parameters = scanner.nextLine().split("\\s");
            String type = parameters[0];
            String name = parameters[1];
            double damage;
            if(parameters[2].equals("null")){
                damage = 45;
            }else{
                damage = Double.parseDouble(parameters[2]);
            }
            double health;
            if(parameters[3].equals("null")){
                health = 250;
            }else{
                health = Double.parseDouble(parameters[3]);
            }
            double armor;
            if(parameters[4].equals("null")){
                armor = 10;
            }else{
                armor = Double.parseDouble(parameters[4]);
            }
            if(!dragons.containsKey(type)){
                dragons.put(type,new TreeMap<>());
            }
            dragons.get(type).put(name,new Dragon(damage,health,armor));
        }

        StringBuilder result = new StringBuilder();

        for (Map.Entry<String, TreeMap<String, Dragon>> type : dragons.entrySet()) {
            double totalDamage = type.getValue().values().stream().mapToDouble(d->d.damage).average().getAsDouble();
            double totalHealth = type.getValue().values().stream().mapToDouble(d->d.health).average().getAsDouble();
            double totalArmor = type.getValue().values().stream().mapToDouble(d->d.armor).average().getAsDouble();
            result.append(String.format("%s::(%.2f/%.2f/%.2f)\n", type.getKey(), totalDamage, totalHealth, totalArmor));
            for (Map.Entry<String,Dragon> dragon : type.getValue().entrySet()) {
                result.append(String.format("-%s -> damage: %.0f, health: %.0f, armor: %.0f\n",
                        dragon.getKey(),
                        dragon.getValue().damage,
                        dragon.getValue().health,
                        dragon.getValue().armor));
            }
        }
        System.out.println(result.toString());
    }
}

class Dragon{
    public double health;
    public double damage;
    public double armor;

    public Dragon(double damage, double health, double armor){
        this.damage = damage;
        this.health = health;
        this.armor = armor;
    }
}
