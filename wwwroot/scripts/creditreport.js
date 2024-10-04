function getSelectedCreditScore() {
    return localStorage.getItem('selectedCreditScore');
}

// Function to set the selected credit score in localStorage
function setSelectedCreditScore(score) {
    localStorage.setItem('selectedCreditScore', score);
}