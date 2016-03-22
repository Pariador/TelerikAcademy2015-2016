# Behavioral Patterns
## Stragegy Pattern
The stragegy pattern allows you to define a family of algorithms so they can be interchangeable and selected at run time.
The pattern involves defining an abstract interface to use a type of algorithm, and then define actual implementations of that type of algorithm.
For example you can define an interface for search algorithms, and then using that inderface define different types of interchangeable searching algorithms.

## Template Method Pattern
The template method pattern defines method that executes and algorithm split into different methods and allows subclasses to override any or all of those mothods.
This way parts of the algorithm can be easily changed.

## Chain of Responsibility Pattern
The chain of responsibility pattern is used to define a series of handler objects, each being able to handle a certain type of object. The core of the pattern is
that if an object is unable to handle the object it passes it down to the next handler in the chain and so on until the proper handler is found or the end of the chain
is reached. The strength of the pattern in when there is too much logic of a single handler, in which case a single handler object may become too big and hard
to manage. By spliting the logic up into different interconnected handlers we achieve looser coupling and stronger cohesion.

## Memento Pattern
The memento pattern is used when an object's state must be stored and easily restored. The pattern defines an object from wich the client can request a memento and then using that
memento can restore the state of the object at the time the memento was created. The memento can either store the state of the object or the series of commands executed on that object.
Repeating those commands would restore the state of the object. The owner of the momento should not chage the memnto.