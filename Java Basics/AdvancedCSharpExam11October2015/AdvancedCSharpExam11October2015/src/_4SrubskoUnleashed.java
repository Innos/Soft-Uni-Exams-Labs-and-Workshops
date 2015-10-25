import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;

public class _4SrubskoUnleashed {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        LinkedHashMap<String,LinkedHashMap<String,Long>> concerts = new LinkedHashMap<>();

        Pattern correctPattern = Pattern.compile("(?<name>[a-zA-Z ]+)\\s@(?<venue>[a-zA-Z ]+)\\s(?<price>\\d+)\\s(?<count>\\d+)");


        String line = scanner.nextLine();
        StringBuilder textSB = new StringBuilder();
        while(!line.equals("End")){
            textSB.append(line);
            textSB.append("\n");
            line = scanner.nextLine();
        }

        String text = textSB.toString();
        Matcher correctMatcher = correctPattern.matcher(text);

        while(correctMatcher.find()){
            String performer = correctMatcher.group("name");
            String venue = correctMatcher.group("venue");
            int price = Integer.parseInt(correctMatcher.group("price"));
            int count = Integer.parseInt(correctMatcher.group("count"));
            long dividents = price * count;

            if(!concerts.containsKey(venue)){
                concerts.put(venue,new LinkedHashMap<>());
            }
            if(!concerts.get(venue).containsKey(performer)){
                concerts.get(venue).put(performer,0L);
            }
            long prevValue = concerts.get(venue).get(performer);
            concerts.get(venue).put(performer,prevValue + dividents);
        }

        for (Map.Entry<String,LinkedHashMap<String,Long>> venue : concerts.entrySet()) {
            System.out.println(venue.getKey());
            Map<String,Long> result = venue
                    .getValue()
                    .entrySet()
                    .stream()
                    .sorted((e1,e2)->-e1.getValue().compareTo(e2.getValue()))
                    .collect(Collectors.toMap(a->a.getKey(),a->a.getValue(),(v1,v2)->v1,LinkedHashMap::new));
            for (Map.Entry<String,Long> performer : result.entrySet()) {
                System.out.printf("#  %s -> %d\n", performer.getKey(), performer.getValue());
            }
        }
    }
}
