DELETE FROM TodoItems
WHERE Title IS NULL
   OR Priority IS NULL
   OR CreatedAt IS NULL
   OR UpdatedAt IS NULL;