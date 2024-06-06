<?php
$servername = "localhost";
$db_username = "root";
$db_password = "";
$dbname = "ticket_sales";

// Create connection
$conn = new mysqli($servername, $db_username, $db_password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} else {
    echo "Database connection successful.<br>";
}

$user_id = NULL; // This will be auto-incremented
$name = $_POST['name']; // Retrieve the name from the form
$address = $_POST['address'];
$city = $_POST['city'];
$state = $_POST['state'];
$postal_code = $_POST['postal_code'];
$phone = $_POST['phone'];
$country = $_POST['country'];
$password = $_POST['password']; // Retrieve the password from the form

// Hash the password
$hashed_password = password_hash($password, PASSWORD_DEFAULT);

// Insert new user with hashed password
$sql = $conn->prepare("INSERT INTO Users (name, address, city, state, postal_code, password) VALUES (?, ?, ?, ?, ?, ?)");
$sql->bind_param("ssssss", $name, $address, $city, $state, $postal_code, $hashed_password);

if ($sql->execute() === TRUE) {
    $user_id = $sql->insert_id;
    echo "New user created successfully.<br>";

    // Insert user profile
    $sql_profile = $conn->prepare("INSERT INTO User_Profiles (user_id, address, city, state, postal_code, country, phone) VALUES (?, ?, ?, ?, ?, ?, ?)");
    $sql_profile->bind_param("issssss", $user_id, $address, $city, $state, $postal_code, $country, $phone);

    if ($sql_profile->execute() === TRUE) {
        echo "User profile created successfully.<br>";
    } else {
        echo "Error: " . $sql_profile->error . "<br>";
    }

    $sql_profile->close();
} else {
    echo "Error: " . $sql->error . "<br>";
}

$sql->close();
$conn->close();
?>
