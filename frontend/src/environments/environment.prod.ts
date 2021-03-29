export const environment = {
    production: true,
    api: {
        base: '//localhost:3000',
        services: {
            activity: '/activity',
            exercises: '/exercises',
            progress: '/progress',
            users: '/users',
        }
    },
    chartSettings: {
        lineChartOptions: {
            annotation: false,
            responsive: true,
            maintainAspectRatio: false,
        },
        lineChartColors: [
            {
                borderColor: '#34a3d7',
                backgroundColor: '#73bee4',
            },
        ]
    }
};
