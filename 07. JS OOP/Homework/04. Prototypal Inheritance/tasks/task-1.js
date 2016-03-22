/* Task Description */
/*
* Create an object domElement, that has the following properties and methods:
  * use prototypal inheritance, without function constructors
  * method init() that gets the domElement type
    * i.e. `Object.create(domElement).init('div')`
  * property type that is the type of the domElement
    * a valid type is any non-empty string that contains only Latin letters and digits
  * property innerHTML of type string
    * gets the domElement, parsed as valid HTML
	  * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
  * property content of type string
    * sets the content of the element
    * works only if there are no children
  * property attributes
    * each attribute has name and value
    * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
  * property children
    * each child is a domElement or a string
  * property parent
    * parent is a domElement
  * method appendChild(domElement / string)
    * appends to the end of children list
  * method addAttribute(name, value)
    * throw Error if type is not valid
  * method removeAttribute(attribute)
*/


/* Example

var meta = Object.create(domElement)
	.init('meta')
	.addAttribute('charset', 'utf-8');

var head = Object.create(domElement)
	.init('head')
	.appendChild(meta)

var div = Object.create(domElement)
	.init('div')
	.addAttribute('style', 'font-size: 42px');

div.content = 'Hello, world!';

var body = Object.create(domElement)
	.init('body')
	.appendChild(div)
	.addAttribute('id', 'cuki')
	.addAttribute('bgcolor', '#012345');

var root = Object.create(domElement)
	.init('html')
	.appendChild(head)
	.appendChild(body);

console.log(root.innerHTML);
Outputs:
<html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
*/

function solve() {
	var domElement = (function () {
		var domElement = {
			init: function(type) {
				this.type = type;
				this.attributes = [];
				this.children = [];

				return this;
			},

			// Properties
			get type() {
				return this._type;
			},
			set type(value) {
				if (typeof(value) !== 'string' || !/^[A-Za-z\d]+$/.test(value)) {
					throw new Error('Type must contain one or more latin letters and digits.\nInvalid value: ' + value);
				}

				this._type = value;
			},
			get parent() {
				return this._parent;
			},
			set parent(value) {
				this._parent = value;
			},
			get content() {
				return this._content;
			},
			set content(value) {
				if (!this.children) {
					throw new Error("Content can only be set if there aren't any children elements.");
				}

				this._content = value;
			},
			get innerHTML() {
				var i,
					len,
					result = '<' + this.type;

				this.attributes.sort(function(firstAttr, secondAttr) {
					if (firstAttr.name > secondAttr.name) {
						return 1;
					}

					if (firstAttr.name < secondAttr.name) {
						return -1;
					}

					return 0;
				});

				for (i = 0, len = this.attributes.length; i < len; i+=1) {
					result += ' ' + this.attributes[i].name + '=' + '"' + this.attributes[i].value + '"';
				}
				result += '>';

				len = this.children.length;
				if (len > 0) {
					for (i = 0, len; i < len; i+=1) {
						if (typeof(this.children[i]) === 'string') {
							result += this.children[i];
						} else {
							result += this.children[i].innerHTML;
						}
					}
				} else if (this.content) {
					result += this.content;
				}

				return result + '</' + this.type + '>';
			},
			children: undefined,
			attributes: undefined,

			// Methods
			appendChild: function(child) {
				this.children.push(child);
				child.parent = this;

				return this;
			},
			addAttribute: function(name, value) {
				var i,
					len;

				if (!/^[A-Za-z\-]+$/.test(name)) {
					throw new Error("Attribute names must contain one or more latin letters or '-'.\nInvalid value: " + name);
				}

				for (i = 0, len = this.attributes.length; i < len; i+=1) {
					if (this.attributes[i].name === name) {
						this.attributes[i].value = value;

						return this;
					}
				}

				this.attributes.push({name: name, value: value});

				return this;
			},
			removeAttribute: function(attrName) {
				var i,
					len;

				for (i = 0, len = this.attributes.length; i < len; i+=1) {
					if (this.attributes[i].name === attrName) {
						this.attributes.splice(i, 1);

						return this;
					}
				}

				throw new Error("Can't remove non-existent attribute.");
			}
		};

		return domElement;
	} ());

	return domElement;
}
// solve();
module.exports = solve;