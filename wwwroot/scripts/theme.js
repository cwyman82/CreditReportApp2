window.themePreference = {
    setTheme: function (theme) {
        try {
            localStorage.setItem("themePreference", theme);
        } catch (error) {
            console.error("Error setting theme preference:", error);
        }
    },

    getTheme: function () {
        try {
            return localStorage.getItem("themePreference");
        } catch (error) {
            console.error("Error getting theme preference:", error);
            return null;
        }
    }
};