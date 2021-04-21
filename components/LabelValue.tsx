import React from 'react';
import { Grid, GridProps, Typography } from '@material-ui/core';

interface LabelValueProps extends GridProps {
  label: React.ReactNode;
  value: React.ReactNode;
}

const LabelValue: React.FC<LabelValueProps> = ({ label, value, ...props }) => {
  return (
    <Grid container item spacing={1} alignItems="baseline" {...props}>
      <Grid item>
        <Typography color="textSecondary">{label}:</Typography>
      </Grid>
      <Grid item>
        <Typography variant="body2">{value}</Typography>
      </Grid>
    </Grid>
  );
};

export default LabelValue;
