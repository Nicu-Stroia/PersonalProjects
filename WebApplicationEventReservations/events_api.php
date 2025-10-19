<?php
require 'config.php';

mysqli_set_charset($conn, "utf8");

$categories =['Business Events', 'Entertainment Events', 'Cultural Events', 'Educational Events', 'Volunteer Events', 'Sports Events'];


foreach ($categories as $category){
    $respone = $conn->query("SELECT id, title, image_url, location, event_date, event_time
                                            FROM events
                                            WHERE category = '$category'
                                            ORDER BY event_date, event_time");
    while($rows = $respone->fetch_assoc()){
        $events[] = $rows;
    }
    $output[$category] = $events;
    $events = [];
}

$conn->close();

echo json_encode($output);