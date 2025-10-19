<?php
require 'config.php';

mysqli_set_charset($conn, "utf8");

$event_ID = $_POST['event_id'];
$name    = $_POST['name'];
$surname = $_POST['surname'];
$email   = $_POST['email'];

$conn->query("INSERT INTO participant (first_name, last_name, email) VALUES ('$name','$surname','$email')
                     ON DUPLICATE KEY UPDATE id=LAST_INSERT_ID(id)");

$participant_ID = $conn->insert_id;

$conn->query("INSERT INTO event_participants (event_id, participant_id) VALUES ('$event_ID', '$participant_ID')");

header("Location: JoinEvents.html");

$conn->close();
