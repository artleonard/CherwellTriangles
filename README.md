# CherwellTriangles

Task #1:
Endpoint to get coordinate values from row and column:
http://localhost:56131/api/Triangles/Triangle?row=B&column=5

Returns:
{"V1x":20,"V1y":10,"V2x":30,"V2y":20,"V3x":20,"V3y":20,"GetRowColumn":{"Row":"B","Column":5}}

Task #2:
Endpoint to get row and column from coordinates:
http://localhost:56131/api/Triangles/Triangle?v1x=50&v1y=0&v2x=60&v2y=0&v3x=60&v3y=10

Returns:
{"Row":"A","Column":12}
