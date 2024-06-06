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

if (isset($_SESSION['user_id'])) {
    $user_id = $_SESSION['user_id'];
    $event_id = $_POST['event_id'];
    $seat_number = $_POST['seat_number'];
    $price = $_POST['price'];

    $sql = $conn->prepare("INSERT INTO Tickets (event_id, user_id, seat_number, price) VALUES (?, ?, ?, ?)");
    $sql->bind_param("iisd", $event_id, $user_id, $seat_number, $price);

    if ($sql->execute() === TRUE) {
        echo "Ticket booked successfully.";
    } else {
        echo "Error: " . $sql->error;
    }

    $sql->close();
} else {
    echo "You need to log in to book a ticket.";
}

$conn->close();
?>
