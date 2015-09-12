import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Dragon{

    private final int AGE_DEATH = 6;
    private final int AGE_LAY_EGGS_START = 3;
    private final int AGE_LAY_EGGS_END = 4;

    private String name;
    private int age;
    public boolean isAlive;
    private List<Egg> eggs;
    private List<Dragon> children;

    public static int dragonsCount = 1;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Dragon> dragons = new ArrayList<>();
        int dragonStart = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <=dragonStart ; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);

            int eggs = Integer.parseInt(scanner.nextLine());
            for (int eggCount = 0; eggCount <eggs ; eggCount++) {
                Egg egg = new Egg(0,dragon);
                dragon.lay(egg);
            }
            dragons.add(dragon);
        }
        dragonsCount = dragonStart + 1;

        int years = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i <years ; i++) {
            String yearType = scanner.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                passAge(dragon,yearFactor);
            }
        }

        for (Dragon dragon : dragons) {
            print(dragon,0);
        }
    }

    public static void passAge(Dragon dragon, YearType yearFactor){
        dragon.age();
        dragon.lay();
        if(dragon.isAlive){
            for (Egg egg : dragon.getEggs()) {
                egg.setYearFactor(yearFactor);
                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child: dragon.getChildren()) {
            passAge(child,yearFactor);
        }
    }

    public static void print(Dragon dragon, int indentation){
        String indent = "";
        for (int i = 0; i <indentation ; i++) {
            indent += " ";
        }
        if(dragon.isAlive){
            System.out.printf("%s%s\n",indent,dragon.getName());
        }

        for (Dragon child : dragon.getChildren()) {
            print(child,indentation + 2);
        }
    }

    public Dragon(String name, int age) {
        this.setAge(age);
        this.setName(name);
        this.isAlive = true;
        this.eggs = new ArrayList<Egg>();
        this.children = new ArrayList<Dragon>();
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public Iterable<Dragon> getChildren() {
        return this.children;
    }

    public int getAge() {
        return age;
    }

    private void setAge(int age) {
        this.age = age;
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        this.name = name;
    }

    public void lay(){
        if(this.age >= AGE_LAY_EGGS_START && this.age <= AGE_LAY_EGGS_END){
            Egg egg = new Egg(-1,this);
            this.eggs.add(egg);
        }
    }

    public void lay(Egg egg){
        this.eggs.add(egg);
    }

    public void age() {
        if(this.isAlive){
            this.age++;
        }
        if(this.age == AGE_DEATH){
            this.isAlive = false;
        }
    }

    public void increaseOffspring(Dragon dragon){
        this.children.add(dragon);
    }
}

class Egg{
    private final int AGE_HATCH = 2;

    private int age;
    private Dragon parent;
    private YearType yearFactor;

    public void setYearFactor(YearType yearType){
        this.yearFactor = yearType;
    }

    public Egg(int age, Dragon parent) {
        this.setAge(age);
        this.setParent(parent);
    }

    public Dragon getParent() {
        return parent;
    }

    private void setParent(Dragon parent) {
        this.parent = parent;
    }

    public int getAge() {
        return age;
    }

    private void setAge(int age) {
        this.age = age;
    }

    public void age(){
        this.age++;
    }

    public void hatch(){

            if(this.age == AGE_HATCH){
                int yearFactor = this.yearFactor.ordinal();
                for (int i = 0; i <yearFactor ; i++) {
                    Dragon baby = new Dragon(this.parent.getName()+"/Dragon_" + Dragon.dragonsCount,-1);
                    this.parent.increaseOffspring(baby);
                    Dragon.dragonsCount++;
                }
        }
    }
}
enum YearType {
    Bad,
    Normal,
    Good
}
