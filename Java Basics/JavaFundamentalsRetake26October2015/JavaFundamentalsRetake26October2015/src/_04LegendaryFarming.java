import java.util.*;
import java.util.stream.Collectors;

public class _04LegendaryFarming {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String,Long> legendaryMaterials = new LinkedHashMap<>();
        TreeMap<String,Long> normalMaterials = new TreeMap<>();
        legendaryMaterials.put("shards",0L);
        legendaryMaterials.put("motes",0L);
        legendaryMaterials.put("fragments",0L);

        String won = "";

        String line = scanner.nextLine();
        while(true){
            String[] parameters = line.split("\\s+");
            for (int i = 0; i < parameters.length; i=i+2) {
                Long ammount = Long.parseLong(parameters[i]);
                String material = parameters[i+1].toLowerCase();

                if(material.equals("shards") || material.equals("motes") || material.equals("fragments")){
                    Long prevAmmount = legendaryMaterials.get(material);
                    legendaryMaterials.put(material,ammount + prevAmmount);
                    if(legendaryMaterials.get("shards") >= 250 && won.equals("")){
                        won = "shards";
                        break;
                    }
                    else if(legendaryMaterials.get("motes") >= 250 && won.equals("")){
                        won = "motes";
                        break;
                    }
                    else if(legendaryMaterials.get("fragments") >= 250 && won.equals("")){
                        won = "fragments";
                        break;
                    }
                }
                else{
                    if(!normalMaterials.containsKey(material)){
                        normalMaterials.put(material,0L);
                    }
                    Long prevAmmount = normalMaterials.get(material);
                    normalMaterials.put(material,ammount + prevAmmount);
                }
            }
            if(!won.equals("")){
                break;
            }
            line = scanner.nextLine();
        }

        if(won.equals("shards")){
            System.out.println("Shadowmourne obtained!");
            Long prevAmmount = legendaryMaterials.get("shards");
            legendaryMaterials.put("shards",prevAmmount-250);
        }
        else if(won.equals("fragments")){
            System.out.println("Valanyr obtained!");
            Long prevAmmount = legendaryMaterials.get("fragments");
            legendaryMaterials.put("fragments",prevAmmount-250);
        }
        else if(won.equals("motes")){
            System.out.println("Dragonwrath obtained!");
            Long prevAmmount = legendaryMaterials.get("motes");
            legendaryMaterials.put("motes",prevAmmount-250);
        }

        legendaryMaterials = legendaryMaterials.entrySet()
                .stream()
                .sorted(new Comparator<Map.Entry<String, Long>>() {
                    @Override
                    public int compare(Map.Entry<String, Long> o1, Map.Entry<String, Long> o2) {
                        int result = -o1.getValue().compareTo(o2.getValue());
                        if(result == 0){
                            result = o1.getKey().compareTo(o2.getKey());
                        }
                        return result;
                    }})
                .collect(Collectors.toMap(a->a.getKey(),b->b.getValue(),(v1,v2)->v1,LinkedHashMap::new));

        for (Map.Entry<String, Long> material : legendaryMaterials.entrySet()) {
            System.out.printf("%s: %d\n", material.getKey(), material.getValue());
        }

        for (Map.Entry<String, Long> normalMaterial : normalMaterials.entrySet()) {
            System.out.printf("%s: %d\n",normalMaterial.getKey(),normalMaterial.getValue());
        }

    }
}