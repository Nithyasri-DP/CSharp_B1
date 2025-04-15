function evaluateMarks()
{
    var m1 = parseFloat(document.getElementById("mark1").value);
    var m2 = parseFloat(document.getElementById("mark2").value);

    // Validate input
    if (isNaN(m1) || isNaN(m2))
    {
        alert("Please enter valid numeric marks for both subjects.");
        return;
    }

    var total = m1 + m2;
    var avg = total / 2;
    var grade = "";

    // Grade Evaluation (using switch)
    switch (true)
    {
        case (avg >= 90):
            grade = "<b><i>Excellent (Grade A)</i></b>";
            break;
        case (avg >= 50):
            grade = "<b><i>Good (Grade B)</i></b>";
            break;
        case (avg >= 35):
            grade = "<b>Average (Grade C)</b>";
            break;
        default:
            grade = "Needs Improvement (Grade D)";
    }

    // Display Result
    document.getElementById("result").innerHTML =
        "Total: " + total + "<br>" +
        "Average: " + avg + "<br>" +
        "Grade: " + grade;

    // Alert and Console Log
    alert("Calculation Complete");
    console.log("Total: " + total + ", Average: " + avg + ", Grade: " + grade);
}
