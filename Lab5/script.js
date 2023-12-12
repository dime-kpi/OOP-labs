document.addEventListener('DOMContentLoaded', function () {
    const containers = document.querySelectorAll('.shuffle-container');
    function shuffleArray(array) {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]];
        }
    }
    containers.forEach(container => {
        const items = Array.from(container.children);
        shuffleArray(items);
        items.forEach(item => {
            container.insertBefore(item, container.children[Math.floor(Math.random() * container.children.length)]);
        });
    });
});


function check() {
    let score = 0;

    //1 відповідь
    const answ1 = document.querySelector('input[name="q1"]:checked');
    if (answ1 && answ1.value === 'a') {
        score += 1.5;
    }
    const answ2 = document.querySelector('input[name="q2"]:checked');
    if (answ2 && answ2.value === 'a') {
        score += 1.5;
    }
    const answ3 = document.querySelector('input[name="q3"]:checked');
    if (answ3 && answ3.value === 'a') {
        score += 1.5;
    }
    const answ4 = document.querySelector('input[name="q4"]:checked');
    if (answ4 && answ4.value === 'a') {
        score += 1.5;
    }
    const answ5 = document.querySelector('input[name="q5"]:checked');
    if (answ5 && answ5.value === 'a') {
        score += 1.5;
    }

    //2 відповіді
    const answ6 = Array.from(document.querySelectorAll('input[name="q6[]"]:checked')).map(answer => answer.value);
    const correct6 = ['a', 'b'];
    score += calculate(answ6, correct6);
    const answ7 = Array.from(document.querySelectorAll('input[name="q7[]"]:checked')).map(answer => answer.value);
    const correct7 = ['a', 'b'];
    score += calculate(answ7, correct7);
    const answ8 = Array.from(document.querySelectorAll('input[name="q8[]"]:checked')).map(answer => answer.value);
    const correct8 = ['a', 'b'];
    score += calculate(answ8, correct8);
    const answ9 = Array.from(document.querySelectorAll('input[name="q9[]"]:checked')).map(answer => answer.value);
    const correct9 = ['a', 'b'];
    score += calculate(answ9, correct9);
    const answ10 = Array.from(document.querySelectorAll('input[name="q10[]"]:checked')).map(answer => answer.value);
    const correct10 = ['a', 'b'];
    score += calculate(answ10, correct10);

    //список
    const answ11 = document.querySelector('select[name="q11"]').value;
    if (answ11 === 'a') {
        score += 3;
    }
    const answ12 = document.querySelector('select[name="q12"]').value;
    if (answ12 === 'a') {
        score += 3;
    }
    const answ13 = document.querySelector('select[name="q13"]').value;
    if (answ13 === 'a') {
        score += 3;
    }
    const answ14 = document.querySelector('select[name="q14"]').value;
    if (answ14 === 'a') {
        score += 3;
    }
    const answ15 = document.querySelector('select[name="q15"]').value;
    if (answ15 === 'a') {
        score += 3;
    }

    // Ваш варіант + складний рівень
    for (let questionNumber = 16; questionNumber <= 25; questionNumber++) {
        const textareaId = `q${questionNumber}`;
        const textarea = document.getElementById(textareaId);
        const userAnswer = textarea.value.trim().toLowerCase();

        // Використовуємо об'єкт для пар відповідей
        const correctAnswers = {
            16: "flex: 1;",
            17: "flex: auto;",
            18: "flex-wrap: wrap;",
            19: "align-items;",
            20: "order: -1;",
            21: "flex: none;",
            22: "justify-content: center;",
            23: "flex: 0 0 auto;",
            24: "align-items: center;",
            25: "flex-basis;",
        };

        // Перевіряємо відповідь та нараховуємо бали
        if (userAnswer === correctAnswers[questionNumber]) {
            score += 5;
        }
    }


    alert(`Загальна сума балів: ${score}`);
}

function calculate(userAnswers, correct) {
    let score = 0;
    for (let i = 0; i < userAnswers.length; i++) {
        if (correct.includes(userAnswers[i])) {
            score += 1.5;
        }
    }
    return score
}