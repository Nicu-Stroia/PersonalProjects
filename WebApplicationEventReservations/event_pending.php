<?php

require 'config.php';

mysqli_set_charset($conn, "utf8");

if(isset($_POST['approve_events'])){
    $result = $conn->query("SELECT title, image_url, location, event_date, event_time, category, creator_id 
                                   FROM pending_events");

   while($row = $result->fetch_assoc()){
    $creator_ID = $row['creator_id'];

    $title     = $row['title'];
    $imageUrl  = "/ProjectPhotos/" . $row['image_url'];
    $location  = $row['location'];
    $eventDate = $row['event_date'];
    $eventTime = $row['event_time'];
    $category  = $row['category'];

    $conn->query("INSERT INTO events (title, image_url, location, event_date, event_time, category) 
                         VALUES('$title', '$imageUrl', '$location', '$eventDate', '$eventTime', '$category')");

    $event_ID = $conn->insert_id;

    $conn->query("INSERT INTO event_creators (creator_id, event_id) VALUES ('$creator_ID', '$event_ID')");
   }
};

$conn->query("TRUNCATE TABLE pending_events");

$conn->close();