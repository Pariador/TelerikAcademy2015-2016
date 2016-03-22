# Structural Patterns

## Facade Pattern:
The facade pattern describes an object which is used to access the functionality of a different object in order to simplify, or improve, its interface.
This is useful for making a complicated object easier to use or if and object's interface is poorly designed, changing it without touching
the object itself. It also further decouples the code which is good.

## Adapter Pattern:
The adapter pattern much like the facade pattern uses one object to access another in order to change its interface, without changing the object itself.
However the goal of the adapter pattern is not to simplify or improve that interface, but merely to adapt it to the current system, in such a way that the code of
the system doesn't need to be changed. This is useful when exchanging the current object with one from a third party library.

## Decorator Pattern:
The decorator pattern, a.k.a. wrapper, is a pattern that offers an alternative to sub-classing and just like normal inheritance its goal is to extend an object's functionality.
The difference is that the object being extended is kept as a private field of the decorator and accessed through the decorator. The decorator can then freely extend that
object's functionality. Both the decorator and the object should implement the same interface. This offers several advantages in comparison to normal inheritance especially,
in languages that disallow multiple inheritance, as decorators can be stacked one after the other adding on both functionalities to the resulting object.
Another advantage to normal inheritance is that these extended objects may be created dynamically. Decorators are also useful when a wide variety of objects is needed,

## Notes:
Code and diagram examples are in the "Code" folder. :D