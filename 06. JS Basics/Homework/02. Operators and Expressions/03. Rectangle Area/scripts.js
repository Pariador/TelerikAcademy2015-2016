// Problem 3. Rectangle area
// Write an expression that calculates rectangle’s area by given width and height.

var result,
	rectangles = [
					{width: 3, height: 4},
					{width: 2.5, height: 3},
					{width: 5, height: 5}
				];

for(rect of rectangles) {
	result = rect.width * rect.height;

	console.log('Width: ' + rect.width + ' Height: ' + rect.height + " Area: " + result);
}