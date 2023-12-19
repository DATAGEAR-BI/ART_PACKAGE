const accessKey = 'modelSecureSecretKey123@';

let secureHandler = {
    get: function (target, prop, receiver) {
        
        if (prop === 'accessWithKey') {
            return function (key) {
                return key === accessKey ? target : null;
            };
        }
        //return Reflect.get(...arguments);
    },
    set: function (target, prop, value, receiver) {
        if (prop === 'accessWithKey') {
            console.warn('Cannot set accessWithKey');
            return false;
        }
        return Reflect.set(...arguments);
    }
    // Add more traps if necessary
};
