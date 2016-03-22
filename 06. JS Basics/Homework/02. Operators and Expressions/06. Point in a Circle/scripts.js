// Problem 6. Point in Circle
// Write an expression that checks if given point P(x, y) is within a circle K({0,0}, 5). //{0,0} is the centre and 5 is the radius

// Examples:
// x		y			inside
// 0		1			true
// -5		0			true
// -4		5			false
// 1.5		-3			true
// -4		-3.5		false
// 100		-30			false
// 0		0			true
// 0.2		-0.8		true
// 0.9		-4.93		false
// 2		2.655		true

var result,
	radius = 5,
	points = [
				{x: 0,  	y: 1},
				{x: -5, 	y: 0},
				{x: -4, 	y: 5},
				{x: 1.5,	y: -3},
				{x: -4, 	y: -3.5},
				{x: 100,	y: -30},
				{x: 0,  	y: 0},
				{x: 0.2,	y: -0.8},
				{x: 0.9,	y: -4.93},
				{x: 2,  	y: -2.655}
			];

for(point of points) {
	result = (Math.abs(point.x) + Math.abs(point.y)) <= radius;

	console.log('Is X: ' + point.x + ' Y: ' + point.y + ' in circle K({0,0}, 5)? Answer: ' + result);
}