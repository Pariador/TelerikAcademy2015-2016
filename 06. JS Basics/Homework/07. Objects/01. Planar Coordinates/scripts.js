// Problem 1. Planar coordinates
// Write functions for working with shapes in standard Planar coordinate system.
// Points are represented by coordinates P(X, Y)
// Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
// Calculate the distance between two points.
// Check if three segment lines can form a triangle.

function createPoint(x, y) {
	return {x: x, y: y};
}

function equalPoints(firstPoint, secondPoint) {
	return (firstPoint.x === secondPoint.x) && (firstPoint.y === secondPoint.y);
}

function distance(firstPoint, secondPoint) {
	return Math.abs(firstPoint.x - secondPoint.x) + Math.abs(firstPoint.y - secondPoint.y);
}

function createLine(firstPoint, secondPoint) {
	return {firstPoint: firstPoint, secondPoint: secondPoint, length: distance(firstPoint, secondPoint)}
}

function canFormTriangle(lineA, lineB, lineC) {
	return (lineA.length <= (lineB.length + lineC.length)) &&
			(lineB.length <= (lineA.length + lineC.length)) &&
			(lineC.length  <= (lineA.length + lineB.length));
}

function createTriangle(pointA, pointB, pointC) {
	if (equalPoints(pointA, pointB) || equalPoints(pointB, pointC) || equalPoints(pointA, pointC)) {
		return;
	}

	return {
		pointA: pointA,
		pointB: pointB,
		pointC: pointC,

		sideA: createLine(pointB, pointC),
		sideB: createLine(pointA, pointC),
		sideC: createLine(pointA, pointB)
	}
}

(function main() {
	var prop,
		validTriangle = createTriangle(createPoint(0, 5), createPoint(5, 0), createPoint(5, 5)),
		invalidTriangle = createTriangle(createPoint(0, 0), createPoint(0, 0), createPoint(0, 0));

	console.log('Valid triangle:');
	console.log(validTriangle);
	console.log('\nInvalid triangle:');
	console.log(invalidTriangle);

	console.log("Are the first tiangle's sides a valid length: " + canFormTriangle(validTriangle.sideA, validTriangle.sideB, validTriangle.sideC))
})();