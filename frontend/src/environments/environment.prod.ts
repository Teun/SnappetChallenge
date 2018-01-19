export const environment = {
  production: true,
  backendUrl: 'http://localhost:5000',
  students: (filterDate, subject, domain, range) =>  {
    return '/api/students?filterDate=' + filterDate + '&subject=' + subject + '&classDomain=' + domain + '&range=' + range;
  },
  subjects: '/api/students/subjects',
  domains: (subject) => '/api/students/domains?subject=' + String(subject)
};
