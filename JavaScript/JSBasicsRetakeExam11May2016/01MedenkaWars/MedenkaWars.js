function calculateMedenkas(input) {
    var vitkorDamage = 0;
    var naskorDamage = 0;
    var naskorCombo = 0;
    var vitkorCombo = 0;
    var lastNaskorDamage = -1;
    var lastVitkorDamage = -1;
    for (var i = 0; i < input.length; i++) {
        var parameters = input[i].split(" ");
        var count = Number(parameters[0]);
        var color = parameters[1];

        var damage = count * 60;

        if (color === "dark") {
            if (naskorCombo === 4 && lastNaskorDamage === damage) {
                damage *= 4.5;
                lastNaskorDamage *= 4.5;
                naskorCombo = 1;
            }
            else if (lastNaskorDamage === damage) {
                naskorCombo++;
            }
            else {
                naskorCombo = 1;
                lastNaskorDamage = damage;
            }
            naskorDamage += damage;
        }
        else if (color === "white") {
            if (vitkorCombo === 1 && lastVitkorDamage === damage) {
                damage *= 2.75;
                vitkorCombo = 0;
            }
            else if (lastVitkorDamage === damage) {
                vitkorCombo++;
            }
            else {
                vitkorCombo = 1;
                lastVitkorDamage = damage;
            }
            vitkorDamage += damage;
        }
    }
    var winner = naskorDamage > vitkorDamage ? "Naskor" : "Vitkor";
    var winnerDmg = naskorDamage > vitkorDamage ? naskorDamage : vitkorDamage;
    console.log(naskorDamage);
    console.log("Winner - " + winner);
    console.log("Damage - " + winnerDmg);
}

var arr2 = ["2 dark medenkas", "1 white medenkas", "2 dark medenkas", "2 dark medenkas", "15 white medenkas", "2 dark medenkas", "2 dark medenkas"]
var arr = ["0 white medenkas", "1 white medenkas", "0 white medenkas","1 white medenkas", "1 white medenkas","1 white medenkas","1 white medenkas","1 white medenkas"];
calculateMedenkas(arr);
