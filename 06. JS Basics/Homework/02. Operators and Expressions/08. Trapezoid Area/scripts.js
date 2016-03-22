// Problem 8. Trapezoid area
// Write an expression that calculates trapezoid's area by given sides a and b and height h.

// Examples:
// a		b		h		area

// 5		7		12		72
// 2		1		33		49.5
// 8.5		4.3		2.7		17.28
// 100		200		300		45000
// 0.222	0.333	0.555	0.1540125

var area,
	trapezoids = [
					{a: 5,		b: 7,		h: 12},
					{a: 2,		b: 1,		h: 33},
					{a: 8.5,	b: 4.3,		h: 2.7},
					{a: 100,	b: 200,		h: 300},
					{a: 0.222,	b: 0.333,	h: 0.555}
				];

for(trapezoid of trapezoids) {
	area = ((trapezoid.a + trapezoid.b) / 2) * trapezoid.h;

	console.log('Trapezoid: { a: ' + trapezoid.a + ', b: ' + trapezoid.b + ' , h: ' + trapezoid.h +
					' }\n' + 'Area: ' + area);
}