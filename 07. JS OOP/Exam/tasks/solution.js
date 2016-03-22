function solve() {
    var validator = {
        stringInRange: function(str, min, max, name) {
            if (typeof(str) !== 'string') {
                throw {
                    name: name + 'NotString',
                    message: name + ' must be a string.'
                };
            }

            // str = str.trim();
            length = str.length;
            if (length < min || max < length) {
                throw {
                    name: name + 'NotInRange',
                    message: name + ' must be a stirng with length between ' + min + ' and ' + max + ' chars.'
                };
            }

            return str;
        }
    };

    var itemProto = (function() {
        var nextId = 0;

        return Object.defineProperties({}, {
            init: {
                value: function(name, description) {
                    this.id = ++nextId;

                    this.name = name;
                    this.description = description;

                    return this;
                }
            },

            description: {
                get: function() {
                    return this._description;
                },
                set: function(value) {
                    if (typeof(value) !== 'string' || value.length === 0) {
                        throw {
                            name: 'InvalidDescription',
                            message: 'Description must be a non-empty string.'
                        };
                    }

                    this._description = value;
                }
            },
            name: {
                get: function() {
                    return this._name;
                },
                set: function(value) {
                    this._name = validator.stringInRange(value, 2, 40, 'name');
                }
            }
        });
    })();

    var bookProto = (function(parent) {
        return Object.defineProperties(Object.create(parent), {
            init: {
                value: function(name, isbn, genre, description) {
                    parent.init.call(this, name, description);

                    this.isbn = isbn;
                    this.genre = genre;

                    return this;
                }
            },

            isbn: {
                get: function() {
                    return this._isbn;
                },
                set: function(value) {
                    var tenOrThirteenDigits = /^(?:(?:\d{10})|(?:\d{13}))$/;

                    if (typeof(value) !== 'string' || !tenOrThirteenDigits.test(value)) {
                        throw {
                            name: 'InvalidIsbn',
                            message: 'Isbn must be a string of either 10 or 13 digits.'
                        };
                    }

                    this._isbn = value;
                }
            },
            genre: {
                get: function() {
                    return this._genre;
                },
                set: function(value) {
                    this._genre = validator.stringInRange(value, 2, 20, 'Genre');
                }
            }
        });
    })(itemProto);

    var mediaProto = (function(parent) {
        return Object.defineProperties(Object.create(parent), {
            init: {
                value: function(name, rating, duration, description) {
                    parent.init.call(this, name, description);

                    this.rating = rating;
                    this.duration = duration;

                    return this;
                }
            },

            rating: {
                get: function() {
                    return this._rating;
                },
                set: function(value) {
                    if (typeof(value) !== 'number' || (value < 1 || 5 < value)) {
                        throw {
                            name: 'InvalidRating',
                            message: 'Rating must be a bmber between 1 and 5.'
                        };
                    }

                    this._rating = value;
                }
            },
            duration: {
                get: function() {
                    return this._duration;
                },
                set: function(value) {
                    if (typeof(value) !== 'number' || value <= 0) {
                        throw {
                            name: 'InvalidDuration',
                            message: 'Duration must be a number greater than 0.'
                        };
                    }

                    this._duration = value;
                }
            }
        });
    })(itemProto);

    var catalogProto = (function() {
        var nextId = 0;

        return Object.defineProperties({}, {
            init: {
                value: function(name) {
                    this.id = ++nextId;
                    this.items = [];

                    this.name = name;

                    return this;
                }
            },

            // Properties
            name: {
                get: function() {
                    return this._name;
                },
                set: function(value) {
                    this._name = validator.stringInRange(value, 2, 40, 'Name');
                }
            },

            // Methods
            add: {
                value: function(items) {
                    var i,
                        len,
                        params = [].slice.call(arguments);

                    if (params.length === 0) {
                        throw {
                            name: 'NoItemsToAdd',
                            message: 'There needs to be atleast one item to add.'
                        };
                    }

                    if (Array.isArray(params[0])) {
                        items = params[0];
                    } else {
                        items = params;
                    }

                    for (i = 0, len = items.length; i < len; i+=1) {
                        if (!itemProto.isPrototypeOf(items[i])) {
                            throw {
                                name: 'ParamNotItem',
                                message: 'Parameter items must be created from itemProto.'
                            };
                        }
                    }

                    this.items = this.items.concat(items);

                    return this;
                }
            },
            find: {
                value: function(param) {
                    var paramType = typeof(param);

                    if (paramType === 'number') {
                        return findItemWithId(param, this);
                    } else if (param !== null && paramType === 'object') {
                        return findItemWithOptions(param, this);
                    } else {
                        throw {
                            name: 'InvalidParamType',
                            message: 'Param must be either a number id or an options object.'
                        };
                    }

                    function findItemWithId(id, thisCatalog) {
                        var i,
                            len;

                        for (i = 0, len = thisCatalog.items.length; i < len; i+=1) {
                            if (thisCatalog.items[i].id === id) {
                                return thisCatalog.items[i];
                            }
                        }

                        return null;
                    }

                    function findItemWithOptions(options, thisCatalog) {
                        return thisCatalog.items.filter(function(item) {
                            var option;
                            for (option in options) {
                                if (item[option] !== options[option]) {
                                    return false;
                                }
                            }

                            return true;
                        });
                    }
                }
            },
            search: {
                value: function(pattern) {
                	if (typeof(pattern) !== 'string' || pattern.length === 0) {
                		throw {
                			name: 'InvalidPattern',
                			message: 'Pattern must be a non-epty string.'
                		};
                	}

                    pattern = pattern.toLowerCase();
                    return this.items.filter(function(item) {
                        var foundInName = item.name.toLowerCase().indexOf(pattern) > -1,
                            foundInDescription = item.description.toLowerCase().indexOf(pattern) > -1;

                        return foundInName || foundInDescription;
                    });
                }
            }
        });
    })();

    var bookCatalogProto = (function(parent) {
        return Object.defineProperties(Object.create(parent), {
            init: {
                value: function(name) {
                    parent.init.call(this, name);

                    return this;
                }
            },
            add: {
                value: function(books) {
                    var i,
                        len,
                        params = [].slice.call(arguments);

                    if (params.length === 0) {
                        throw {
                            name: 'NoBooksToAdd',
                            message: 'There needs to be atleast one book to add.'
                        };
                    }

                    if (Array.isArray(params[0])) {
                        books = params[0];
                    } else {
                        books = params;
                    }

                    areAllBooks = !books.some(function(book) {
                        return !bookProto.isPrototypeOf(book);
                    });
                    if (!areAllBooks) {
                        throw {
                            name: 'NotAllBooks',
                            message: 'All books have to be created from bookProto.'
                        };
                    }

                    parent.add.call(this, books);

                    return this;
                }
            },
            getGenres: {
                value: function() {
                    var genre,
                        result = [],
                        uniqueGenres = {};

                    this.items.forEach(function(book) {
                        uniqueGenres[book.genre.toLowerCase()] = true;
                    });

                    for (genre in uniqueGenres) {
                        result.push(genre);
                    }

                    return result;
                }
            }
        });
    })(catalogProto);

    var mediaCatalogProto = (function(parent) {
        return Object.defineProperties(Object.create(parent), {
            init: {
                value: function(name) {
                    parent.init.call(this, name);

                    return this;
                }
            },
            add: {
                value: function(mediaArr) {
                    var i,
                        len,
                        params = [].slice.call(arguments);

                    if (params.length === 0) {
                        throw {
                            name: 'NoMediaToAdd',
                            message: 'There needs to be atleast one media to add.'
                        };
                    }

                    if (Array.isArray(params[0])) {
                        mediaArr = params[0];
                    } else {
                        mediaArr = params;
                    }

                    areAllMedia = !mediaArr.some(function(media) {
                        return !mediaProto.isPrototypeOf(media);
                    });
                    if (!areAllMedia) {
                        throw {
                            name: 'NotAllMedia',
                            message: 'All media have to be created from mediaProto.'
                        };
                    }

                    parent.add.call(this, mediaArr);
                    return this;
                }
            },
            getTop: {
                value: function(count) {
                    var topCountMedia;
                    	result = [];

                    if (typeof(count) !== 'number' || count < 1) {
                        throw {
                            name: 'InvalidCount',
                            message: 'Count must be a number greater than 1.'
                        };
                    }

                    this.items.sort(function(firstMedia, sedondMedia) {
                        return firstMedia.rating - sedondMedia.rating;
                    });

                    this.items.reverse();

                    topCountMedia = this.items.slice(0, count);

                    topCountMedia.forEach(function(media) {
                    	result.push({
                    		id: media.id,
                    		name: media.name
                    	});
                    });

                    return result
                }
            },
            getSortedByDuration: {
            	value: function() {
            		return this.items.sort(function(first, second) {
            			if (first.duration === second.duration) {
							return first.id - second.id;
            			}

            			return second.duration - first.duration;
            		});
            	}
            }
        });
    })(catalogProto);

    return {
        getBook: function (name, isbn, genre, description) {
            //return a book instance
            return Object.create(bookProto).init(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            //return a media instance
            return Object.create(mediaProto).init(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            //return a book catalog instance
            return Object.create(bookCatalogProto).init(name);
        },
        getMediaCatalog: function (name) {
            //return a media catalog instance
            return Object.create(mediaCatalogProto).init(name);
        }
    };
}

module.exports = solve;