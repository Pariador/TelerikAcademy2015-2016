// Problem 9. Point in Circle and outside Rectangle
// Write an expression that checks for given point P(x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2) .

// Examples:
// x 		y	 		inside
// 1 		2	 		yes
// 2.5	 	2			yes
// 0 		1	 		no
// 2.5	 	1			no
// 2 		0	 		no
// 4 		0	 		no
// 2.5 		1.5  		yes
// 2 		1.5  		yes
// 1 		2.5  		yes
// -100		-100 		no

var result,
	inCircle,
	outRect,
	circle = {
				centerPoint: { x: 1, y: 1},
				radius: 3
			},
	rectangle = {
					topLeftPoint: {x: -1, y: 1},
					width: 6,
					height: 2
			},
	points = [
				{x: 1, 		y: 2},
				{x: 2.5, 	y: 2},
				{x: 0,		y: 1},
				{x: 2.5, 	y: 1},
				{x: 2, 		y: 0},
				{x: 4, 		y: 0},
				{x: 2.5, 	y: 1.5},
				{x: 2, 		y: 1.5},
				{x: 1, 		y: 2.5},
				{x: -100, 	y: -100}
			];

for(point of points) {
	inCircle = (Math.abs(point.x - circle.centerPoint.x) + Math.abs(point.y - circle.centerPoint.y)) <= circle.radius;

	outRect = point.x > (rectangle.topLeftPoint.x + rectangle.width) || point.x < rectangle.topLeftPoint.x ||
				point.y < (rectangle.topLeftPoint.y - rectangle.height) || point.y > rectangle.topLeftPoint.y;

	result = (inCircle && outRect)? 'yes' : 'no';

	console.log('Point: { x:  ' + point.x + ', y: ' + point.y + ' }\nResult: ' + result);
}