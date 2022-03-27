import { trigger, transition, animate, style, query, group } from '@angular/animations';

const distances = {
  normalX: 'translateX(0%)',
  right: 'translateX(100%)',
  left: 'translateX(-100%)',
};

export const slideInAnimation = trigger('routeAnimations', [
  transition('ActualLevelPage => RelativeProgressPage', [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        width: '100%',
      }),
    ]),
    query(':leave', [style({ transform: distances.normalX })]),
    query(':enter', [style({ transform: distances.right })]),
    group([
      query(':leave', [animate('1000ms ease-out', style({ transform: distances.left }))]),
      query(':enter', [animate('1000ms ease-out', style({ transform: distances.normalX }))]),
    ]),
  ]),

  transition('RelativeProgressPage => ActualLevelPage', [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        width: '100%',
      }),
    ]),
    query(':leave', [style({ transform: distances.normalX })]),
    query(':enter', [style({ transform: distances.left })]),
    group([
      query(':leave', [animate('1000ms ease-out', style({ transform: distances.right }))]),
      query(':enter', [animate('1000ms ease-out', style({ transform: distances.normalX }))]),
    ]),
  ]),
]);
