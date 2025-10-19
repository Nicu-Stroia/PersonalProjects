<?php
require 'config.php';

mysqli_set_charset($conn, "utf8");

$creatorName = $_POST['name'];
$creatorSurname = $_POST['surname'];
$creatorEmail = $_POST['email'];

$conn->query("INSERT INTO creator (first_name, last_name, email) VALUES ('$creatorName', '$creatorSurname', '$creatorEmail')
                     ON DUPLICATE KEY UPDATE id=LAST_INSERT_ID(id)");

$creator_ID = $conn->insert_id;

$eventCategory = $_POST['event_category'];
$eventTitle    = $_POST['event_title'];
$eventLocation = $_POST['event_location'];
$eventDate     = $_POST['event_date'];
$eventTime     = $_POST['event_time'];

$tmp  = $_FILES['event_image']['tmp_name'];
$ext  = strtolower(pathinfo($_FILES['event_image']['name'], PATHINFO_EXTENSION));
$new = preg_replace('/[^a-zA-Z0-9\._-]/', '_', basename($_FILES['event_image']['name']));
move_uploaded_file($tmp, __DIR__ . '/ProjectPhotos/' . $new);

$eventImage = $new;

$conn->query("INSERT INTO pending_events (title, image_url, location, event_date, event_time, category, creator_id)
                     VALUES ('$eventTitle', '$eventImage', '$eventLocation', '$eventDate', '$eventTime', '$eventCategory', '$creator_ID')");

header("Location: CreateEvent.html");
$conn->close();
