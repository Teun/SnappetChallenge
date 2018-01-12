// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  backendUrl: 'http://localhost:5000',
  students: (filterDate, subject, domain, range) =>  {
    return '/api/students?filterDate=' + filterDate + '&subject=' + subject + '&classDomain=' + domain + '&range=' + range;
  },
  subjects: '/api/students/subjects',
  domains: (subject) => '/api/students/domains?subject=' + String(subject)
};
