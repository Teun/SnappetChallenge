import type { NextApiRequest, NextApiResponse } from 'next';
import { isSameDay, parseISO, startOfDay } from 'date-fns/fp';

import type { Exercise } from '@lib/models/Exercise';
import data from '@Data/work.json';

export default (req: NextApiRequest, res: NextApiResponse) => {
  const { date } = req.query;
  if (!date || typeof date !== 'string') {
    res.status(400).end();
    return;
  }

  let parsedDate: Date;
  try {
    parsedDate = startOfDay(parseISO(date));
  } catch (e) {
    res.status(400).end();
    return;
  }

  const exercises = (data as Exercise[])
    .map((item) => ({
      ...item,
      SubmitDateTime: item.SubmitDateTime + 'Z',
    }))
    .filter((item) => {
      const submitDateTime = new Date(item.SubmitDateTime);
      return isSameDay(startOfDay(submitDateTime).getTime(), parsedDate.getTime());
    });

  res.status(200).json(exercises);
};
