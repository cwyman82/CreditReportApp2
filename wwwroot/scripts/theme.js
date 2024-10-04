//window.themePreference = {
//    setTheme: function (theme) {
//        console.log("set theme");
//        try {
//            localStorage.setItem("themePreference", theme);
//        } catch (error) {
//            console.error("Error setting theme preference:", error);
//        }
//    },

//    getTheme: function () {
//        console.log("get theme");
//        try {
//            return localStorage.getItem("themePreference");
//        } catch (error) {
//            console.error("Error getting theme preference:", error);
//            return null;
//        }
//    }
//};

window.themePreference = {
    setTheme: function (theme) {
        console.log("set theme to", theme);
        try {
            localStorage.setItem("themePreference", theme);
        } catch (error) {
            console.error("Error setting theme preference:", error);
        }
    },

    getTheme: function () {
        console.log("getting theme");
        try {
            return localStorage.getItem("themePreference");
        } catch (error) {
            console.error("Error getting theme preference:", error);
            return null;
        }
    }
};