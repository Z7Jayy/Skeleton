<?php
session_start();
$servername = "localhost";
$db_username = "root";
$db_password = "";
$dbname = "ticket_sales";

// Check if user is logged in
if (!isset($_SESSION['user_id'])) {
    header("Location: index.html");
    exit;
}

$user_id = $_SESSION['user_id'];

// Create connection
$conn = new mysqli($servername, $db_username, $db_password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Fetch user data
$sql = $conn->prepare("SELECT Users.name, Users.address, Users.city, Users.state, Users.postal_code, User_Profiles.phone, User_Profiles.country 
                       FROM Users 
                       JOIN User_Profiles ON Users.user_id = User_Profiles.user_id 
                       WHERE Users.user_id = ?");
$sql->bind_param("i", $user_id);
$sql->execute();
$sql->bind_result($name, $address, $city, $state, $postal_code, $phone, $country);
$sql->fetch();
$sql->close();

$conn->close();
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>User Profile</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center">User Profile</h1>
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Name: <?php echo htmlspecialchars($name); ?></h5>
                <p class="card-text">Address: <?php echo htmlspecialchars($address); ?></p>
                <p class="card-text">City: <?php echo htmlspecialchars($city); ?></p>
                <p class="card-text">State: <?php echo htmlspecialchars($state); ?></p>
                <p class="card-text">Postal Code: <?php echo htmlspecialchars($postal_code); ?></p>
                <p class="card-text">Phone: <?php echo htmlspecialchars($phone); ?></p>
                <p class="card-text">Country: <?php echo htmlspecialchars($country); ?></p>
            </div>
        </div>
        <a href="logout.php" class="btn btn-danger mt-3">Logout</a>
    </div>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
