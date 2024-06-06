<?php
session_start();
$servername = "localhost";
$db_username = "root";
$db_password = "";
$dbname = "ticket_sales";

$conn = new mysqli($servername, $db_username, $db_password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$name = $_POST['name'];
$password = $_POST['password'];

$sql = $conn->prepare("SELECT user_id, password FROM Users WHERE name = ?");
$sql->bind_param("s", $name);
$sql->execute();
$sql->store_result();
$sql->bind_result($user_id, $hashed_password);
$sql->fetch();

if ($sql->num_rows > 0 && password_verify($password, $hashed_password)) {
    $_SESSION['user_id'] = $user_id;
    $_SESSION['name'] = $name;
    echo "Login successful. Welcome, $name.";
    // Redirect to user dashboard or homepage
    header("Location: dashboard.php");
} else {
    echo "Invalid name or password.";
}

$sql->close();
$conn->close();
?>
